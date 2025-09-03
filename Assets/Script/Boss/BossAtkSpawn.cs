using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtkSpawn : MonoBehaviour
{
    public GameObject prefab; // 생성할 프리팹
    public float spawnRadius = 5f; // 생성 반경

    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnPrefabNearPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPrefabNearPlayer()
    {
        // 플레이어 주변에서 랜덤한 위치를 생성합니다.
        Vector3 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + randomOffset;

        // 생성된 위치에 프리팹을 생성합니다.
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}

