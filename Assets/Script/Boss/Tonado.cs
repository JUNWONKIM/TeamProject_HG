using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonado : MonoBehaviour
{
    public float pullForce = 5f; 
    public bool isPlayerTriggered = false;
    Transform player; 
    public float speed = 5f;

    public AudioClip ATKsoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(ATKsoundClip);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;
        Vector2 direction = player.position - transform.position; //플레이어 방향
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
        Destroy(gameObject, 10.0f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어 충돌
        {
            player = other.transform; //플레이어 위치 저장
            isPlayerTriggered = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어 충돌 유지
        {
            //회오리 중심에서 플레이어 위치 계산
            Vector2 pullDirection = transform.position - player.position;
           
            // 중심으로 당김
           player.GetComponent<Rigidbody2D>().AddForce(pullDirection.normalized * pullForce);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //플레이어 빠져 나갈때
        {
            player = null; // 플레이어 위치 해제
            isPlayerTriggered = false;
        }
    }

}
