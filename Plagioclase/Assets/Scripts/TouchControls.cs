using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    //Pinch Zoom
    public float perspectiveZoomSpeed = .5f;
    public float orthographicZoomSpeed = .5f;

    void Update()
    {
        //Tap Touches
        Touch myTouch = Input.GetTouch(0);
        myTouch.phase = TouchPhase.Began;

        //Multiple Tap Touches
        Touch[] myTouches = Input.touches;
        for(int i = 0; i < Input.touchCount; i++)
        {
            Debug.Log(myTouches[i].phase);
        }

        //Accelerometer
        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);


        //Pinch Zoom
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPreviousPostion = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePreviousPostion = touchOne.position - touchOne.deltaPosition;

            float previousTouchDeltaMagnitude = (touchZeroPreviousPostion - touchOnePreviousPostion).magnitude;
            float touchDeltaMagnitude = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDifference = previousTouchDeltaMagnitude - touchDeltaMagnitude;

            Camera cam = GetComponent<Camera>();

            if(cam.orthographic)
            {
                cam.orthographicSize += deltaMagnitudeDifference * orthographicZoomSpeed;
                cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);

            }
            else
            {
                cam.fieldOfView += deltaMagnitudeDifference * perspectiveZoomSpeed;
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 0.1f, 179.9f);

            }

        }
    }
}
