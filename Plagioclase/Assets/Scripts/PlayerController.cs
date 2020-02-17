using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed = 0.1f;
    public bool isBoosting = false;
    public float maxHealth = 100f;
    public float currentHealth;
    public float currentBoost;
    public float maxBoost = 30f;
    public Image boostBar;

    public Rigidbody2D astro;

    public float verticalVelocity;
    public bool touchedGround = false;
    public GameObject ground;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool playerAlive = true;

    public void Start()
    {
        currentBoost = maxBoost;
        currentHealth = maxHealth;

        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    public void Update()
    {
        verticalVelocity = astro.velocity.magnitude;

        if (playerAlive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isBoosting = true;
            }
            else
            {
                isBoosting = false;
            }

            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            Vector2 movement = new Vector2(moveHorizontal, 0);
            astro.AddForce(movement * horizontalSpeed);

            boostBar.fillAmount = currentBoost / maxBoost;

            if (isBoosting)
            {
                astro.gravityScale = 0;
                astro.drag = 10;
                horizontalSpeed = 0.1f;
                currentBoost = currentBoost - 1 * Time.deltaTime;
            }
            else if (!isBoosting)
            {
                astro.gravityScale = 0.3f;
                astro.drag = 0;
                horizontalSpeed = 0.3f;
            }

            touchedGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        }


        if (verticalVelocity >= 6 && touchedGround)
        {
            currentHealth = 0;
        }

    }
    public void LateUpdate()
    {
        if(currentHealth <= 0)
        {
            playerAlive = false;
        }
    }


}
