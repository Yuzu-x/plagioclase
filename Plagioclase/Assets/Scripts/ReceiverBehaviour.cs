using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverBehaviour : MonoBehaviour
{

    void OnTouchDown()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }
    void OnTouchUp()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
    void OnTouchStay()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    void OnTouchExit()
    {
        GetComponent<Renderer>().material.color = Color.white;

    }
}
