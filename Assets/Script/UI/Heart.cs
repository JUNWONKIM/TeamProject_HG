using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private LifeText lifetext;

    

    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;
    public GameObject heart_4;
    public GameObject heart_5;
    void Start()
    {
        lifetext = GameObject.Find("LifeText").GetComponent<LifeText>();
    }

    private void Update()
    {

        if(lifetext.life == 5)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(true);
            heart_4.SetActive(true);
            heart_5.SetActive(true);
        }

        if (lifetext.life == 4)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(true);
            heart_4.SetActive(true);
            heart_5.SetActive(false);
        }

        if (lifetext.life == 3)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(true);
            heart_4.SetActive(false);
            heart_5.SetActive(false);
        }

        if (lifetext.life == 2)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(false);
            heart_4.SetActive(false);
            heart_5.SetActive(false);
        }

        if (lifetext.life == 1)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(false);
            heart_3.SetActive(false);
            heart_4.SetActive(false);
            heart_5.SetActive(false);
        }

        if (lifetext.life == 0)
        {
            heart_1.SetActive(false);
            heart_2.SetActive(false);
            heart_3.SetActive(false);
            heart_4.SetActive(false);
            heart_5.SetActive(false);
        }




    }


}
