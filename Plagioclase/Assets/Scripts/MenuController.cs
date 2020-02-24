using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text introText;
    public Image boostPanel;
    public Image boostBar;
    public Image deathScreen;
    public Camera cam;
    public GameObject marker;
    public GameObject astronaut;
    public float gameStartTimer = 0f;
    public bool startGame = false;

    List<GameObject> deathMarkers = new List<GameObject>();


    void Start()
    {
        marker.GetComponent<Rigidbody2D>().gravityScale = 0f;
        introText.enabled = true;
        boostPanel.enabled = false;
        boostBar.enabled = false;
        astronaut.GetComponent<Rigidbody2D>().gravityScale = 0f;
        deathScreen.enabled = false;

    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            introText.enabled = false;
            marker.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            startGame = true;
        }

        if(startGame)
        {
            gameStartTimer = gameStartTimer + 1 * Time.deltaTime;
        }

        if(marker.transform.position.y <= 5.75)
        {
            marker.GetComponent<Rigidbody2D>().drag = 500f;
        }

        if(gameStartTimer == 2f)
        {
            marker.GetComponent<Rigidbody2D>().drag = 100f;
        }

        if(gameStartTimer >= 4.5f)
        {
            cam.GetComponent<CamStart>().enabled = false;
            marker.SetActive(false);
            cam.GetComponent<CameraFollow>().enabled = true;

            astronaut.GetComponent<Rigidbody2D>().AddForce(transform.right * -.15f);

            startGame = false;

            boostPanel.enabled = true;
            boostBar.enabled = true;

            if (astronaut.transform.position.y < 4)
            {
                gameStartTimer = 0;
            }
        }

        foreach(GameObject marker in GameObject.FindGameObjectsWithTag("Marker"))
        {
            deathMarkers.Add(marker);

        }

        if(deathMarkers.Count > 1)
        {
            deathMarkers.RemoveAt(0);
        }
    }
}
