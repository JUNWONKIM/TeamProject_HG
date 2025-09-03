using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundBGM : MonoBehaviour
{
    public AudioClip backgroundClip; 
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
