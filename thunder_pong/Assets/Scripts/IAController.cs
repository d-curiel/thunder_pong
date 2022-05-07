using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : IPlayerController
{
    GameObject ball;
    [SerializeField]
    float speed;
    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }
    void FixedUpdate()
    {
        if (GameManager._instance.IsGameStarted())
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, ball.transform.position.y), speed * Time.deltaTime);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    float RandomHitFactor(){
        return (Random.Range(0f, 1f) - 0.5f);
    }
}
