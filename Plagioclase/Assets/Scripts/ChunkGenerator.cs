using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public GameObject layout1;
    public GameObject layout2;
    public GameObject layout3;
    public GameObject layout4;
    public GameObject player;

    public GameObject nextLayout;

    public float layoutPicker;

    public BoxCollider2D topCollider;

    public float prevLayoutTop;


    void Start()
    {
        layoutPicker = Random.Range(1, 5);
        if(layoutPicker == 1)
        {
            nextLayout = layout1;
        }
        else if(layoutPicker == 2)
        {
            nextLayout = layout2;
        }
        else if(layoutPicker == 3)
        {
            nextLayout = layout3;
        }
        else if(layoutPicker == 4)
        {
            nextLayout = layout4;
        }
        Instantiate(nextLayout, new Vector2(0, -16), Quaternion.identity);

        topCollider = nextLayout.GetComponent<BoxCollider2D>();


    }
    

    void OnTriggerEnter2D(Collider2D layout)
    {
        if (layout.gameObject.tag == "Layout")
        {
            Debug.Log("I am triggered by " + layout);
            layoutPicker = Random.Range(1, 5);
            if (layoutPicker == 1)
            {
                nextLayout = layout1;
            }
            else if (layoutPicker == 2)
            {
                nextLayout = layout2;
            }
            else if (layoutPicker == 3)
            {
                nextLayout = layout3;
            }
            else if (layoutPicker == 4)
            {
                nextLayout = layout4;
            }
            Instantiate(nextLayout, new Vector2(0, player.transform.position.y - 31.3f), Quaternion.identity);
        }
    }
}
