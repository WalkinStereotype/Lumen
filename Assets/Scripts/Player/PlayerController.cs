using System;
using UnityEngine;
using System.Collections;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Get rigid body and sprite renderer and animation
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    
    private bool facing = false; //For animation

    //Movement constants
    public float gravityMultiplier = 1f;
    public float moveSpeed;
    public float jumpSpeed;
    public float floatingTime = 0.1f;
    public float xMin;
    public float xMax;
    public float yBoundary;

    private float preservedY;

    //Respawn coordinate
    private Vector3 spawnPoint;

    //GroundDetection Script
    private GroundDetection feet;

    void Start()
    {
        rb.gravityScale = gravityMultiplier;
        spawnPoint = transform.position;
        feet = GetComponent<GroundDetection>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Respawn();
            return;
        }
        
        if (GameManager.instance.getDarkness())
        {
            float horizontalInput = Input.GetAxis("Horizontal"); //horizontal input (1 or -1)

            float currentVerticalVelocity = rb.linearVelocity.y; //current vertical velocity

            // Check if we fell off the map
            if (transform.position.y < yBoundary)
            {
                // GameManager.instance.ShowGameOverScreen(false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && feet.GetIsGrounded())
            {
                currentVerticalVelocity = jumpSpeed;
                // animator.SetBool("Jump", true);
                // sr.color = Color.red;

                Debug.Log("jumping");
            }

            Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, currentVerticalVelocity);
            rb.linearVelocity = newVelocity;
            anim.SetFloat("Velocity", math.abs(newVelocity.x));
            anim.SetBool("Concentrate", false);
            if (newVelocity.x < 0)
            {
                facing = true;
            }
            else if (newVelocity.x > 0)
            {
                facing = false;
            }
            sr.flipX = facing;

            // animator.SetFloat("Run", Mathf.Abs(horizontalInput));
            // sr.flipX = horizontalInput < 0f;
            // animator.SetFloat("Vertical", currentVerticalVelocity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // preservedY = rb.linearVelocity.y;
            // preservedY = Mathf.clamp(preservedY, p, 0);
            // rb.linearVelocity = new Vector2(0, 0);

            StartCoroutine(HoverAndDrop());
            if (anim.GetBool("Concentrate") == false)
            {
                anim.SetBool("Concentrate", true);
            }

            Debug.Log("concentrating");

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
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Void"))
        {
            Debug.Log("Player died");
            AudioManager.instance.PlayDeath();
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("Player won");
            AudioManager.instance.PlayWin();
            StartCoroutine(WaitAndLoadScene(2f));
        }
    }

    private IEnumerator WaitAndLoadScene(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        // Get the current scene index and load the next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        // Ensure time scale is set back to normal
        Time.timeScale = 1;
    }

    private void Respawn()
    {
        transform.position = spawnPoint;
        GameManager.instance.RestartLevel();
    }
}