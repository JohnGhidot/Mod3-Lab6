using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour    
{
    [SerializeField] float speed = 4f;
    [SerializeField] float lifetime = 2f;
    Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //_rb.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public float GetSpeed() => speed;
}
