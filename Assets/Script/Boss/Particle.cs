using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float delay = 2f;
    public GameObject candyPrefab;

    public AudioClip crunchsoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("SpawnPrefab", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPrefab()
    {
        audioSource.PlayOneShot(crunchsoundClip);
        Instantiate(candyPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
