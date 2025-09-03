using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public float spawnDelay = 0f; 
    public float spawnInterval = 5f; 
    public float minDistanceToPlayer = 10f; 
    public GameObject spawnAreaObject; 
    private Rect spawnArea; 

   
    void Start()
    {
        Vector3 position = spawnAreaObject.transform.position; //소환 위치
        Vector3 scale = spawnAreaObject.transform.localScale; //소환 범위
        spawnArea = new Rect(position.x - scale.x / 2f, position.z - scale.z / 2f, scale.x, scale.z); //소환 범위 지정
        InvokeRepeating("Spawn", spawnDelay, spawnInterval); //일정 간격으로 소환
    }

    void Spawn()
    {
        if (!gameObject.activeSelf)
        {
            return; 
        }

        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 spawnPos = Vector3.zero;

        // 소환 영역안에서 랜덤 위치 구함
        float x = Random.Range(spawnArea.xMin, spawnArea.xMax);
        float z = Random.Range(spawnArea.yMin, spawnArea.yMax);
        spawnPos = new Vector3(x, 0f, z);  

        // 플레이어와 최소 거리 유지
        while (Vector3.Distance(spawnPos, playerPos) < minDistanceToPlayer)
        {
            x = Random.Range(spawnArea.xMin, spawnArea.xMax);
            z = Random.Range(spawnArea.yMin, spawnArea.yMax);
            spawnPos = new Vector3(x, 0f, z);
        }

        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; //랜덤 적 지정
        Instantiate(randomEnemyPrefab, spawnPos, Quaternion.identity); //랜덤 적 소환

    }

}
