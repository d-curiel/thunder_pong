using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    float startPoint, length;
    [SerializeField]
    float parallaxSpeed;

    float artificialMovement;
    void Start()
    {
        artificialMovement = 0;
        startPoint = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    void FixedUpdate()
    {
        
        artificialMovement += parallaxSpeed * Time.deltaTime;
        transform.position = new Vector3(startPoint + artificialMovement, transform.position.y, transform.position.z);
        if (transform.position.x > startPoint + length)
        {
            artificialMovement = 0;
        }
        
    }
}
