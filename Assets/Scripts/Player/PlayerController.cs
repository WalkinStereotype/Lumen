using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float gravityMultiplier = 1f;
    public float moveSpeed;
    public float jumpSpeed;
    private bool isGrounded = true;

    public float floatingTime = 0.1f;

    // public Animator animator;

    public float xMin;
    public float xMax;
    public float yBoundary;

    private float preservedY;

    private Vector3 spawnPoint;

    void Start()
    {
        rb.gravityScale = gravityMultiplier;
        spawnPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.getDarkness())
        {
            float horizontalInput = Input.GetAxis("Horizontal"); //horizontal input (1 or -1)
            float currentVerticalVelocity = rb.linearVelocity.y; //current vertical velocity

            // Check if we fell off the map
            if (transform.position.y < yBoundary)
            {
                // GameManager.instance.ShowGameOverScreen(false);
            }

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                currentVerticalVelocity = jumpSpeed;
                isGrounded = false;
                // animator.SetBool("Jump", true);
                // sr.color = Color.red;
            }

            Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, currentVerticalVelocity);
            rb.linearVelocity = newVelocity;

            // animator.SetFloat("Run", Mathf.Abs(horizontalInput));
            // sr.flipX = horizontalInput < 0f;
            // animator.SetFloat("Vertical", currentVerticalVelocity);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // preservedY = rb.linearVelocity.y;
            // preservedY = Mathf.clamp(preservedY, p, 0);
            // rb.linearVelocity = new Vector2(0, 0);

            StartCoroutine(HoverAndDrop());

        }


    }

    IEnumerator HoverAndDrop()
    {
        rb.linearVelocity = new Vector2(0, 0); // Stop all velocity
        rb.gravityScale = 0; // Disable gravity

        yield return new WaitForSeconds(floatingTime); // Hover duration

        rb.gravityScale = gravityMultiplier; // Re-enable gravity
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

            if (!isGrounded)
            {
                // Audio
                if (GameManager.instance.getDarkness())
                {
                    AudioManager.instance.PlayDarkThud();
                }
                else
                {
                    AudioManager.instance.PlayLightThud();
                }
            }


            isGrounded = true;

            // animator.SetBool("Jump", false);
            // sr.color = Color.green;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player died");
            AudioManager.instance.PlayDeath();
            Time.timeScale = 1;
            transform.position = spawnPoint;
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Player won");
            AudioManager.instance.PlayWin();
            Time.timeScale = 0;
        }

    }
}