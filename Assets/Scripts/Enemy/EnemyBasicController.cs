using UnityEngine;

public class EnemyBasicController : MonoBehaviour
{
    // private float duration = 0f;
    private Rigidbody2D rb;
    public float speed = 2f;
    // public float patrolInterval = 3f;
    private bool goingRight = true;
    private Vector2 preservedMotion;

    public float minX;
    public float maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (minX == 0.0f && maxX == 0.0f)
        {
            float xPost = transform.position.x;
            minX = xPost - 2;
            maxX = xPost + 2;
        }

        rb.linearVelocity = new Vector2(1, 0) * speed;
        preservedMotion = rb.linearVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.getDarkness())
        {
            rb.linearVelocity = preservedMotion;

            //TIME BASED OSCILLATION
            // duration += Time.deltaTime;
            // if (duration >= patrolInterval)
            // {
            //     rb.linearVelocity *= -1;

            //     duration -= patrolInterval;
            // }

            //POSITION BASED OSCILLATION
            float xPos = transform.position.x;

            if(goingRight)
            {
                if (xPos >= maxX)
                {
                    rb.linearVelocity *= -1;
                    preservedMotion = rb.linearVelocity;
                    goingRight = false;
                }
            }
            else
            {
                if (xPos <= minX)
                {
                    rb.linearVelocity *= -1;
                    preservedMotion = rb.linearVelocity;
                    goingRight = true;
                }
            }

        } 
        else
        {
            rb.linearVelocity *= 0;
        }

        // Debug.Log("velocity = " + rb.linearVelocity.x);

    }
}
