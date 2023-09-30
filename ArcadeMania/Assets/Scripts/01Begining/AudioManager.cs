using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource gameSounds;

    [SerializeField] AudioClip bulletHitSound, bulletHitShellSound, deathSound, teleportSound, healthSound, coinSound, roundWonSound;

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
        gameSounds.clip = deathSound;
        gameSounds.Play();
    }

    public void PlayTeleportSound()
    {
        gameSounds.clip = teleportSound;
        gameSounds.Play();
    }

    public void PlayBulletHitSound(float volume = 0.8f)
    {
        gameSounds.volume = volume;
        gameSounds.clip = bulletHitSound;
        gameSounds.Play();
    }

    public void PlayHealthPickupSound()
    {
        gameSounds.clip = healthSound;
        gameSounds.Play();
    }
    public void PlayCoinSound()
    {
        gameSounds.clip = coinSound;
        gameSounds.Play();
    }
    public void PlayRoundWonSound()
    {
        gameSounds.clip = roundWonSound;
        gameSounds.Play();
    }
}
