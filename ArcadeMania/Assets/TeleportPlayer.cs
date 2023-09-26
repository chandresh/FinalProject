using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] Transform teleportTarget;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = teleportTarget.position;
            audioSource.Play();
        }
    }
}
