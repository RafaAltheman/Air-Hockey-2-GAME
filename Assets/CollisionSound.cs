using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionSound : MonoBehaviour
{
    public AudioClip hit;
    public float minInterval = 0.05f; // evita metralhadora de som
    public float volume = 0.6f;

    private AudioSource audioSrc;
    private float lastTime;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.playOnAwake = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!hit) return;
        if (Time.time - lastTime < minInterval) return;

        lastTime = Time.time;
        audioSrc.PlayOneShot(hit, volume);
    }
}
