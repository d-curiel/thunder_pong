using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;
    [SerializeField]
    string axis;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager._instance.IsGameStarted()){
            float v = Input.GetAxisRaw(axis);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
        }
    }
    
}
