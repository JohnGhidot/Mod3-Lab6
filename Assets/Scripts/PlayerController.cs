using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private int speed = 5;
    Vector2 dir;
    float h;
    float v;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        dir = new Vector2(h, v);
        _rb.MovePosition(_rb.position + dir * (speed * Time.deltaTime));
    }
}
