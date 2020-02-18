using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public LayerMask touchableMask;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] oldTouches;

    private RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            oldTouches = new GameObject[touchList.Count];
            touchList.CopyTo(oldTouches);
            touchList.Clear();

            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, touchableMask))
            {
                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);

                if(Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("TouchedUp");
                }
                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("TouchedStay");
                }
                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("TouchedDown");
                }
            }
            foreach (GameObject recipient in oldTouches)
            {
                if (!touchList.Contains(recipient))
                {
                    recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);

                }
            }
        }
#endif
        #region TouchInput
        if (Input.touchCount > 0)
        {
            oldTouches = new GameObject[touchList.Count];
            touchList.CopyTo(oldTouches);
            touchList.Clear();

            foreach(Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
                if(Physics.Raycast(ray, out hit, touchableMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if(touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchMove", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchCancel", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                }
            }

            foreach(GameObject recipient in oldTouches)
            {
                if(!touchList.Contains(recipient))
                {
                    recipient.SendMessage("OnTouchCancel", hit.point, SendMessageOptions.DontRequireReceiver);

                }
            }
        }
        #endregion
    }
}
