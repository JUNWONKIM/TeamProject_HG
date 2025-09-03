using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 10f; // 레이저 이동 속도

    private Vector3 direction; // 레이저 발사 방향

    public AudioClip LasersoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(LasersoundClip);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

   
}
