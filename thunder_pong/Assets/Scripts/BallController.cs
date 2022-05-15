using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private static int HITS_UNTIL_INCREMENT_SPEED = 10;
    private static float SPEED_INCREMENT_FACTOR = 0.5f;
    private static float BASE_SPEED = 20f;
    [SerializeField]
    float speed = 20f;
    [SerializeField]
    GameObject ballStartPosition;
    int playersHit = 0;

    void Start()
    {
        InitialBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            SetNewDirection(collision, 1);
            IncrementBallHits();
        }
        else if (collision.gameObject.name == "Player2")
        {
            SetNewDirection(collision, -1);
            IncrementBallHits();
        }
        CheckSpeedIncrement();

    }

    private void SetNewDirection(Collision2D collision, int direction)
    {
        float y = hitFactor(this.transform.position, collision.transform.position, collision.collider.bounds.size.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction, y).normalized * speed;
    }
    private void IncrementBallHits()
    {
        playersHit++;
    }
    private void CheckSpeedIncrement()
    {
        if (playersHit == HITS_UNTIL_INCREMENT_SPEED)
        {
            speed += SPEED_INCREMENT_FACTOR;
            playersHit = 0;
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
        this.speed = BASE_SPEED;
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
