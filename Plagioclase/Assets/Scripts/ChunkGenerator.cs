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
    public GameObject layout8;
    public GameObject layout9;
    public GameObject layout10;
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
        layoutPicker = Random.Range(1, 11);
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
        else if (layoutPicker == 8)
        {
            nextLayout = layout8;
        }
        else if (layoutPicker == 9)
        {
            nextLayout = layout9;
        }
        else if (layoutPicker == 10)
        {
            nextLayout = layout10;
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

        if (powerUpClone != null)
        {
            if (powerUpClone.transform.position.y >= player.transform.position.y + 20 || powerUpClone.transform.position.y <= player.transform.position.y - 80)
            {
                Destroy(powerUpClone);
                powerUpClone = null;
            }
        }

    }




    void OnTriggerEnter2D(Collider2D layout)
    {
        if (layout.gameObject.tag == "Layout")
        {
            layoutPicker = Random.Range(1, 11);
            powerUpSpawner = Random.Range(1, 6);

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
            else if (layoutPicker == 8)
            {
                nextLayout = layout8;
            }
            else if (layoutPicker == 9)
            {
                nextLayout = layout9;
            }
            else if (layoutPicker == 10)
            {
                nextLayout = layout10;
            }

            if (powerUpSpawner == 1 && powerUpClone == null)
            {
                powerUpClone = Instantiate(boosterPU, new Vector2(0, layout.transform.position.y), Quaternion.identity);
            }
            layoutClone = Instantiate(nextLayout, new Vector2(0, layout.transform.position.y - 8f), Quaternion.identity);
            layoutGeneratedOrder.Add(layoutClone);
        }

        if(layout.gameObject.tag == "Booster")
        {
            Destroy(powerUpClone);
            powerUpClone = null;
        }
    }
}
