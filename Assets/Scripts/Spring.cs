using UnityEngine;

public class Spring : MonoBehaviour
{
    public float boingSpeed = 15f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Before Boing");
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Key"))
        {
            Debug.Log("Boing");
            // AudioManager.instance.PlayDeath();
            
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Set the vertical velocity directly to bounceSpeed
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, boingSpeed);
            }
        }
    }
}
