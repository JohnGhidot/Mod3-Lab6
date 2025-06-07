using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour    
{

    [SerializeField] float _speed;
    private PlayerController _playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void Awake()
    {
        _playerController = Object.FindObjectOfType<PlayerController>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        float dir = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _playerController.transform.position, dir);
        //transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
    }
}
