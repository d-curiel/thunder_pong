using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class IPlayerController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip collisionSound;
    float audioVolume = 0.5f;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioVolume;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}