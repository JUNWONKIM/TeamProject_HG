using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlespawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 소환할 잡몹 프리팹들
    public float spawnInterval = 1f; // 소환 간격 (초)
    public float spawnRadius = 5f; // 소환 위치 반경

    public AudioClip craklesoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void OnDisable()
    {
        CancelInvoke("SpawnEnemy");
    }

    void SpawnEnemy()
    {
        // 랜덤으로 잡몹 프리팹 선택
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[randomIndex];

        // 주변 랜덤 위치 계산
        Vector2 bossPosition = transform.position;
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector2 spawnPosition = bossPosition + randomOffset;

        // 잡몹 생성
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        audioSource.PlayOneShot(craklesoundClip);
    }

    //private IEnumerator SpawnEnemies()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(spawnInterval);

    //        // 랜덤으로 잡몹 프리팹 선택
    //        int randomIndex = Random.Range(0, enemyPrefabs.Length);
    //        GameObject enemyPrefab = enemyPrefabs[randomIndex];

    //        // 주변 랜덤 위치 계산
    //        Vector2 bossPosition = transform.position;
    //        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
    //        Vector2 spawnPosition = bossPosition + randomOffset;

    //        // 잡몹 생성
    //        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    //    }
    //}

}
