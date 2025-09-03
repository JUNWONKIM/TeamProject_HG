using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public GameObject spherePrefab; // 구체 프리팹
    public float spawnInterval = 5f; // 구체 생성 간격
    public float spawnRadius = 5f; // 소환 위치 반경
    public float laserDelay = 2f; // 구체 생성 후 레이저 발사까지의 시간 지연

    private Transform playerTransform; // 플레이어의 위치

   
    public AudioClip AtksoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnSpheres()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnSphere();
        }
        audioSource.PlayOneShot(AtksoundClip);
    }

    void SpawnSphere()
    {
        // 보스 주변 랜덤한 위치 계산
        Vector3 randomPosition = CalculateRandomPosition();

        // 구체 생성 및 위치 이동
        GameObject sphere = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
        sphere.GetComponent<SphereController>().SetTimerAndPlayerTransform(laserDelay, playerTransform);
        
    }

    Vector3 CalculateRandomPosition()
    {
        // 보스 위치를 기준으로 반지름 범위 내에서 랜덤한 위치를 계산합니다.
        Vector3 bossPosition = transform.position; // 보스의 위치
        float radius = 5f; // 반지름 범위

        // 랜덤한 각도를 계산합니다.
        float randomAngle = Random.Range(0f, 360f);
        // 랜덤한 위치를 계산합니다.
        Vector3 randomOffset = Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right * radius;
        // 보스 위치와 랜덤한 오프셋을 합산하여 최종 위치를 계산합니다.
        Vector3 randomPosition = bossPosition + randomOffset;

        return randomPosition;
    }
    void OnDisable()
    {
        CancelInvoke("SpawnSpheres");
    }

    void OnEnable()
    {
        
        InvokeRepeating("SpawnSpheres", 0f, spawnInterval);
    }
}

