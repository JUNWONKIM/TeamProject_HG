using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{
    public GameObject prefabToCreate;
    public float delay = 5f;

    private void Start()
    {
        Invoke("CreatePrefab", delay);
    }

    private void CreatePrefab()
    {
        Instantiate(prefabToCreate, transform.position, Quaternion.identity);
    }
}
