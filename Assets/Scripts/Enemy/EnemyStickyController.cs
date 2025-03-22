using UnityEngine;

public class EnemyStickyController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1f;
    public int currentWaypointIndex = 0;
    public SpriteRenderer sr;

    private Vector2 lastPosition;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
    }

    void Update()
    {
        if (waypoints.Length == 0) return;
        if (!GameManager.instance.getDarkness()) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        
        // if (targetWaypoint.position.x < transform.position.x)
        // {
        //     sr.flipX = true; // Moving left
        // }
        // else if (targetWaypoint.position.x > transform.position.x)
        // {
        //     sr.flipX = false; // Moving right
        // }

        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.05f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        //Logic for sprite orientation
        Vector2 movementDirection = (Vector2)transform.position - lastPosition;
        if (movementDirection.magnitude > 0.01f) // Avoid jittering
        {
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        lastPosition = transform.position; // Update last position

    }
}
