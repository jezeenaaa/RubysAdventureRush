using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;

        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.x = position.x + Time.deltaTime * speed;
            position.y = position.y + Time.deltaTime * speed;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed;
        }

        rigidbody2D.MovePosition(position);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }

       
    }
}
