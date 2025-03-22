using UnityEngine;

public class EnemyStickyController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1f;
    public int currentWaypointIndex = 0;
    public SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (waypoints.Length == 0) return;
        if (!GameManager.instance.getDarkness()) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        
        if (targetWaypoint.position.x < transform.position.x)
        {
            sr.flipX = true; // Moving left
        }
        else if (targetWaypoint.position.x > transform.position.x)
        {
            sr.flipX = false; // Moving right
        }

        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.05f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

    }
}
