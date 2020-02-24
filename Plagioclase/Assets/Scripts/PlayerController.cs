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
    public ParticleSystem boostParticles;

    public Rigidbody2D astro;

    public float verticalVelocity;
    public bool touchedGround = false;
    public GameObject ground;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public ParticleSystem trail;
    public GameObject deathSpot;
    List<GameObject> deathMarks = new List<GameObject>();

    public bool isIntro = true;
    public Animator animator;

    public bool playerAlive = true;
    public bool headMarked = false;

    public void Start()
    {
        currentBoost = maxBoost;
        currentHealth = maxHealth;
        trail.Stop();
        boostParticles.Stop();

        ground = GameObject.FindGameObjectWithTag("Ground");

        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        verticalVelocity = astro.velocity.magnitude;

        if (playerAlive && !isIntro && transform.position.y < 4.5f)
        {
            astro.gravityScale = 0.3f;
            if (Input.GetKey(KeyCode.Space) && currentBoost > 0)
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
                boostParticles.Play();
            }
            else if (!isBoosting)
            {
                astro.gravityScale = 0.3f;
                astro.drag = 0;
                horizontalSpeed = 0.3f;
            }

            touchedGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        }


        if (verticalVelocity >= 6f)
        {
            trail.Play();

            if (touchedGround)
            {
                currentHealth = 0;
            }
        }
        else
        {
            trail.Stop();
        }

        if(transform.position.y >= 4.78)
        {
            isIntro = true;

            if (transform.position.y <= 4.79)
            {
                animator.SetBool("isIntro", true);
            }

        }
        else
        {
            isIntro = false;
            animator.SetBool("isIntro", false);
        }

        if (transform.position.y >= 0)
        {
            astro.gravityScale = 0.1f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Booster")
        {
            currentBoost = currentBoost + 10f;
            if(currentBoost > maxBoost)
            {
                currentBoost = maxBoost;
            }
        }
    }
    public void LateUpdate()
    {
        if(currentHealth <= 0)
        {
            playerAlive = false;
            OnDeath();
        }
    }


    public void OnDeath()
    {
        if(verticalVelocity == 0 && !headMarked)
        {
            GameObject deathMarker = Instantiate(deathSpot, transform.position, Quaternion.identity) as GameObject;
            deathMarks.Add(deathMarker);
            headMarked = true;
        }

        if(deathMarks.Count > 1)
        {
            deathMarks.RemoveAt(0);

        }
    }
}
