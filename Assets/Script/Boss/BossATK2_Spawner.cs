using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATK2_Spawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;

    private Transform player;
    private float nextFireTime;
    Vector2 lookDirection_1;
    Vector2 lookDirection_2;
    Vector2 lookDirection_3;

    public AudioClip ATKsoundClip;
    private AudioSource audioSource;
  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();       
    }

  
    void Update()
    {
    
        lookDirection_1 = player.position - transform.position;
        lookDirection_2 = new Vector2(player.position.x - transform.position.x + 2f, player.position.y - transform.position.y + 2f);
        lookDirection_3 = new Vector2(player.position.x - transform.position.x - 2f, player.position.y - transform.position.y - 2f);

        if (Time.time >= nextFireTime)
        {
        
            audioSource.PlayOneShot(ATKsoundClip);

           
            nextFireTime = Time.time + fireRate;

           
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = lookDirection_1.normalized * bulletSpeed;


            Vector2 spawnPosition_2 = transform.position + new Vector3(1.5f, 0f, 0f);
            GameObject bullet_1 = Instantiate(bulletPrefab, spawnPosition_2, transform.rotation);
            bullet_1.GetComponent<Rigidbody2D>().linearVelocity = lookDirection_2.normalized * bulletSpeed;

            Vector2 spawnPosition_3 = transform.position + new Vector3(-1.5f, 0f, 0f);
            GameObject bullet_2 = Instantiate(bulletPrefab, spawnPosition_3, transform.rotation);
            bullet_2.GetComponent<Rigidbody2D>().linearVelocity = lookDirection_3.normalized * bulletSpeed;

        }
    }
}

