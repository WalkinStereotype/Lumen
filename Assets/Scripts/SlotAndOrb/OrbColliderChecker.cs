using UnityEngine;

public class OrbColliderChecker : MonoBehaviour
{
    private bool initialThud = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(initialThud)
            {
                initialThud = false;
            }
            else 
            {
                AudioManager.instance.PlayOrbThud();
            }
        }
    }
}
