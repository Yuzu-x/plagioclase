using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;

    public Vector3 offset;

    void Start()
    {
        offset.x = 0;
        offset.y = transform.position.y - player.transform.position.y - 1;
        offset.z = -10;
    }


    void LateUpdate()
    {
        transform.position = new Vector3(0, player.transform.position.y, 0) + offset;   
        if(transform.position.x != 0)
        {
            transform.position = new Vector3(0, player.transform.position.y, 0) + offset;
        }
    }
}
