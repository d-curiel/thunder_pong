using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    float speed = 20f;
    [SerializeField]
    GameObject ballStartPosition;

    void Start()
    {
        InitialBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float y = hitFactor(this.transform.position, collision.transform.position, collision.collider.bounds.size.y);
        if (collision.gameObject.name == "Player1")
        {
            Vector2 direction = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (collision.gameObject.name == "Player2")
        {
            Vector2 direction = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;

        }

    }

    float hitFactor(Vector2 player, Vector2 ball, float playerWidth)
    {
        return ((ball.y - player.y) / playerWidth);
    }


    public void InitialBall()
    {
        InitBall();
        Invoke("_InitialBallMovement", 2.0f);
    }
    private void _InitialBallMovement()
    {

        float random = Random.Range(0, 2);
        if (random < 1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
    }

    public void InitBallAfterScore()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            StartCoroutine(LaunchBall(Vector2.right));
        }
        else
        {
            StartCoroutine(LaunchBall(Vector2.left));
        }
        InitBall();
    }

    private IEnumerator LaunchBall(Vector2 direction)
    {

        yield return new WaitForSeconds(2.0f);
        GetComponent<Rigidbody2D>().velocity = direction * speed;

    }
    private void InitBall()
    {
        transform.position = ballStartPosition.transform.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
