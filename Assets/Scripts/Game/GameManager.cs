using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // public GameObject gameOverScreen; 

    // public TextMeshProUGUI gameOverMessage;
    private bool isDark = true;

    public GameObject spriteObject; // Assign the sprite GameObject in the Inspector

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
    }

    

    void Update()
    {
        if (isDark && Input.GetKeyDown(KeyCode.Space))
        {
            isDark = false;
            spriteObject.SetActive(false);
        }
        else if (!isDark && Input.GetKeyUp(KeyCode.Space))
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
    
}

