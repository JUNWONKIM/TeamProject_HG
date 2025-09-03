using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endSceneChange : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public float delay = 10f;
    public float delay2 = 20f;

    private void Start()
    {
        Invoke("SwitchObjects", delay);
        Invoke("SwitchObjects2", delay2 );
    }

    private void SwitchObjects()
    {
        object1.SetActive(!object1.activeSelf);
        object2.SetActive(!object2.activeSelf);

    }

    private void SwitchObjects2()
    {
        object2.SetActive(!object2.activeSelf);
        object3.SetActive(!object3.activeSelf);
    }
}
