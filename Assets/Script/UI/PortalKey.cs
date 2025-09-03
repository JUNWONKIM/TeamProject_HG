using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKey : MonoBehaviour
{
    public GameObject spawnPrefab; // 생성될 프리팹
    private GameObject spawner;
    public string targetTag;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null)
            {
                spawner.SetActive(false); // LifeText 오브젝트를 비활성화
            }

            DestroyObjectsWithTag();
            SpawnPrefabInCenter();
            Destroy(gameObject);
        }
    }
    private void DestroyObjectsWithTag()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }

    private void SpawnPrefabInCenter()
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // 맵 중앙 위치로 수정해주세요.
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(spawnPrefab, spawnPosition, spawnRotation);
    }
}
