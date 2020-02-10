using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;

    public Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    void LateUpdate()
    {
        transform.position = new Vector3(0, player.transform.position.y, 0) + offset;   
    }
}
