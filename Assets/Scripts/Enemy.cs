using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour    
{

    [SerializeField] float _speed;
    private PlayerController _playerController;
    private AudioSource audioSource;
    private AudioClip hitClip;
    [SerializeField]
    private float hitSoundVolume = 1f;

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
        audioSource = GetComponent<AudioSource>();
        hitClip = Resources.Load<AudioClip>("SFX/Explosion1");
    }

    public void PlayHitSound()
    {
        if (audioSource != null && hitClip != null)
        {
            audioSource.PlayOneShot(hitClip, hitSoundVolume);
        }
        else
        {
            Debug.LogWarning("AudioSource o hitClip non assegnati nel nemico!");
        }
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
