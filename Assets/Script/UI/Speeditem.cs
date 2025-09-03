using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeditem : MonoBehaviour
{
   

    private PlayerMove playerController; // 플레이어 컨트롤러

  
    // Start is called before the first frame update
    void Start()
    {
      
        Destroy(gameObject,2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerMove>();
            if (playerController != null && playerController.speed == 3.0)
            {
              
                playerController.StartSpeedBoost();
                // 아이템 효과 시작
                Destroy(gameObject);
                
            }
        }
    }
    

}
