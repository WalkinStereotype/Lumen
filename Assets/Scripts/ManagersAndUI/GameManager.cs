using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // public GameObject gameOverScreen; 

    // public TextMeshProUGUI gameOverMessage;
    private bool isDark = true;

    public GameObject spriteObject; // Assign the sprite GameObject in the Inspector

    public GameObject keyObject;
    private Vector3 keyRespawn;
    public GameObject slotKeyObject;
    public GameObject gateObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // gameOverMessage.text = "You died!";
        spriteObject.SetActive(true);

        // Save the initial position of the key
        if (keyObject != null)
        {
            keyRespawn = keyObject.transform.position;
        }
    }

    

    void Update()
    {
        if (isDark && Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDark = false;
            spriteObject.SetActive(false);
        }
        else if (!isDark && Input.GetKeyUp(KeyCode.LeftShift))
        {
            isDark = true;
            spriteObject.SetActive(true);
        }
    }

    // public void ShowGameOverScreen(bool didWin)
    // {
    //     Time.timeScale = 0;
    //     Debug.Log("Game Lose");
    //     if (didWin)
    //     {
    //         gameOverMessage.text = "Success!";
    //     }
    //     gameOverScreen.SetActive(true);
    // }

    public bool getDarkness()
    {
        return isDark;
    }

    public void RestartLevel()
    {
        if (keyObject != null)
        {
            keyObject.SetActive(true);
            keyObject.transform.position = keyRespawn;

            Rigidbody2D rb = keyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Set the vertical velocity directly to bounceSpeed
                rb.linearVelocity = Vector2.zero;
            }
        }

        if (slotKeyObject != null)
        {
            slotKeyObject.SetActive(false);
        }

        if (gateObject != null)
        {
            gateObject.SetActive(false);
        }
    }
    
}

