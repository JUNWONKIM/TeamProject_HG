using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpawn : MonoBehaviour
{
    public GameObject prefab; 
    public float spawnInterval = 15f; // 생성 간격

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // 타이머 값을 감소시킵니다.

        if (timer <= 0f)
        {
            SpawnPrefab();
            timer = spawnInterval; // 타이머를 다시 생성 간격으로 설정합니다.
        }
    }
    private void SpawnPrefab()
    {
        // 프리팹을 현재 위치에 생성합니다.
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
