using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Itemdrop : MonoBehaviour
{
    public GameObject[] itemPrefabs; // 드롭될 아이템 프리팹들
    private float dropProbability = 0.7f; // 아이템이 드롭될 확률
    // Start is called before the first frame update
    void Start()
    {
        float rd; 
        rd = Random.value;
        
        if (rd <= dropProbability)
        {
            if (rd < 0.15f && SceneManager.GetActiveScene().name != "Boss")
            {
                GameObject item = Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
            }
            else
            {
                int randomIndex = Random.Range(0, 2);
                GameObject item = Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
            }
            // 아이템을 랜덤으로 선택하여 드롭합니다.
        }
        Destroy(gameObject, 2.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
