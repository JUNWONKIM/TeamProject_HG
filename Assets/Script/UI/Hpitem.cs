using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpitem : MonoBehaviour
{
    private LifeText lifetext;

   
    // Start is called before the first frame update
    void Start()
    {
      
        lifetext = GameObject.Find("LifeText").GetComponent<LifeText>();
        Destroy(gameObject,2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            lifetext.Heal();
            Destroy(gameObject);
        }
    }
}
