using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource basicAudioSource;

    public AudioClip lightThud;
    public AudioClip darkThud;
    public AudioClip death;
    public AudioClip win;
    public AudioClip orbThud;
    public AudioClip orbUnlock;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager persistent
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayLightThud()
    {
        basicAudioSource.PlayOneShot(lightThud);
    }
    public void PlayDarkThud()
    {
        basicAudioSource.PlayOneShot(darkThud);
    }
    public void PlayDeath()
    {
        basicAudioSource.PlayOneShot(death);
    }

    public void PlayWin()
    {
        basicAudioSource.PlayOneShot(win);
    }

    public void PlayOrbThud()
    {
        basicAudioSource.PlayOneShot(orbThud);
    }

    public void PlayOrbUnlock()
    {
        basicAudioSource.PlayOneShot(orbUnlock);
    }
    

}
