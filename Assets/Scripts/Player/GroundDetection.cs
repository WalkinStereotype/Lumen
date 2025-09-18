using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class GroundDetection : MonoBehaviour
{
    private bool isGrounded;
    private bool playedThud;

    void Start()
    {
        isGrounded = true;
        playedThud = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            //If just started touching ground, play thud sounds
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
            Debug.Log("Entered ground");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Exited ground");
        }
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}