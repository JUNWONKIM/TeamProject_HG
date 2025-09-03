using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� Prefab
    public float bulletSpeed = 10f; // �Ѿ� �ӵ�
    public float fireRate = 0.5f; // �߻� ����

    private float nextFire = 0f; // ���� �߻� ���� �ð�

    public AudioClip ATKsoundClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            audioSource.PlayOneShot(ATKsoundClip);

            nextFire = Time.time + fireRate;

            // �Ѿ� Prefab ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // �Ѿ� �߻� ���� ���
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction.Normalize();

            // �Ѿ� �߻�
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.linearVelocity = direction * bulletSpeed;
        }
    }
}