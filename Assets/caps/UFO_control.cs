using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UFO_control : MonoBehaviour
{

    public float spawnRate = 5.5f;
    public float lastSpawnTime = 0.0f;
    public GameObject bulletCandidate;
    public GameObject[] bulletDirection;
    public float currentTime = 0.0f;

    void Start()
    {
        InvokeRepeating("bulletGenerate", 0.5f, 1.5f);
    }


   

    // Update is called once per frame
    void Update()
    {
        
    }

    void bulletGenerate()
    {
        for (int i = 0; i < 5; i++)
        {
            bulletCandidate.transform.rotation = bulletDirection[i].transform.rotation;
            Instantiate(bulletCandidate, bulletDirection[i].transform.position, bulletCandidate.transform.rotation);
            lastSpawnTime = currentTime;
        }
    }

   
}
