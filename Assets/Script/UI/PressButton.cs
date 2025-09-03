using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    public int nextSceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
            int totalSceneCount = SceneManager.sceneCountInBuildSettings;

            int nextSceneIndex = (currentSceneNumber + nextSceneNumber) % totalSceneCount;

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
