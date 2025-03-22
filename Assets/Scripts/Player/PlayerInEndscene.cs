using System;
using UnityEngine;
using System.Collections;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerInEndscne : MonoBehaviour
{
    //Get sprite renderer and animation

    public SpriteRenderer sr;
    public Animator anim;
    
    private bool facing = false; //For animation

    private bool spaceDown = false;

    // Update is called once per frame
    void Update()
    {
        
        if (!spaceDown)
        {
            float horizontalInput = Input.GetAxis("Horizontal"); //horizontal input (1 or -1)

            // anim.SetFloat("Velocity", math.abs(horizontalInput));
            if (horizontalInput < 0)
            {
                facing = true;
            }
            else if (horizontalInput > 0)
            {
                facing = false;
            }
            sr.flipX = facing;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceDown = true;
            if (anim.GetBool("Concentrate") == false){
                anim.SetBool("Concentrate", true);
            }

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            spaceDown = false;
            anim.SetBool("Concentrate", false);
        }


    }
}