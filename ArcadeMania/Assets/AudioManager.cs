using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgmSource; // Background Music
    public AudioSource sfxSource; // Sound Effects

    public AudioClip bulletHitSound, bulletHitShellSound, deathSound, teleportSound;

    float sfxVolume = 0.8f;

    void Awake()
    {
        //Singleton Pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDeathSound()
    {
        sfxSource.clip = deathSound;
        sfxSource.Play();
    }

    public void PlayTeleportSound()
    {
        sfxSource.clip = teleportSound;
        sfxSource.Play();
    }

    public void PlayBulletHitSound(float volume = 0.8f)
    {
        sfxSource.volume = volume;
        sfxSource.clip = bulletHitSound;
        sfxSource.Play();
    }
}
