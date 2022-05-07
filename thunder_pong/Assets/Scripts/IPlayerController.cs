using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class IPlayerController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip collisionSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}