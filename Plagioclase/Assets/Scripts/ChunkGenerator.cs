using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public GameObject layout1;
    public GameObject layout2;
    public GameObject layout3;
    public GameObject layout4;
    public GameObject layout5;
    public GameObject layout6;
    public GameObject layout7;
    public GameObject player;

    public GameObject boosterPU;

    public GameObject nextLayout;

    public float layoutPicker;
    public float powerUpSpawner;
    private List<GameObject> layoutGeneratedOrder = new List<GameObject>();
    public GameObject layoutClone;
    public GameObject powerUpClone;
    public GameObject oldestLayoutClone;

    public BoxCollider2D topCollider;



    void Start()
    {
        layoutPicker = Random.Range(1, 8);
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
        else if (layoutPicker == 5)
        {
            nextLayout = layout5;
        }
        else if (layoutPicker == 6)
        {
            nextLayout = layout6;
        }
        else if (layoutPicker == 7)
        {
            nextLayout = layout7;
        }
       layoutClone = Instantiate(nextLayout, new Vector2(0, -16), Quaternion.identity);
        layoutGeneratedOrder.Add(layoutClone);
        topCollider = nextLayout.GetComponent<BoxCollider2D>();


    }

    void Update()
    {
        if (oldestLayoutClone == null)
        {

            oldestLayoutClone = layoutGeneratedOrder[0];
        }

       if (oldestLayoutClone.transform.position.y >= player.transform.position.y + 30)
        {

            layoutGeneratedOrder.Remove(layoutGeneratedOrder[0]);
            Destroy(oldestLayoutClone);

        }

    }




    void OnTriggerEnter2D(Collider2D layout)
    {
        if (layout.gameObject.tag == "Layout")
        {
            layoutPicker = Random.Range(1, 8);
            powerUpSpawner = Random.Range(1, 9);

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
            else if (layoutPicker == 5)
            {
                nextLayout = layout5;
            }
            else if (layoutPicker == 6)
            {
                nextLayout = layout6;
            }
            else if (layoutPicker == 7)
            {
                nextLayout = layout7;
            }

            if(powerUpSpawner == 1)
            {
                powerUpClone = Instantiate(boosterPU, new Vector2(Random.Range(-2, 3), layout.transform.position.y - 8f), Quaternion.identity);
            }
            else
            {
                powerUpSpawner = 0;
            }
                 layoutClone = Instantiate(nextLayout, new Vector2(0, layout.transform.position.y - 8.0f), Quaternion.identity);
            layoutGeneratedOrder.Add(layoutClone);
        }
    }
}
