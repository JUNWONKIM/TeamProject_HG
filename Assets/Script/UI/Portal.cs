using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public AudioClip PortalsoundClip;
    private AudioSource audioSource;

    public int nextSceneNumber; // 다음 씬의 번호를 설정할 변수

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(PortalsoundClip);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
            int totalSceneCount = SceneManager.sceneCountInBuildSettings;

            int nextSceneIndex = (currentSceneNumber + nextSceneNumber) % totalSceneCount;

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
