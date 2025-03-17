using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
