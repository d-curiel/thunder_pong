using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IPlayerController
{
    [SerializeField]
    float speed = 20f;
    [SerializeField]
    string axis;

    float currentSpeed;
    float speedSmooth = 2.5f;
    void Start()
    {
        currentSpeed = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager._instance.IsGameStarted())
        {
            float v = Input.GetAxisRaw(axis);
            if (v == 0)
            {
                currentSpeed = 0f;
            }
            else
            {
                if (currentSpeed >= speed)
                {
                    currentSpeed = speed;
                }
                else
                {
                    currentSpeed += speedSmooth;
                }

            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * currentSpeed;
            

        }
    }

}
