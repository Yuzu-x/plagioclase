using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStart : MonoBehaviour
{
    public GameObject marker;

    public Vector3 offset;

    void Start()
    {
        offset = transform.position - marker.transform.position;
    }


    void LateUpdate()
    {
        transform.position = new Vector3(0, marker.transform.position.y, 0) + offset;
    }
}
