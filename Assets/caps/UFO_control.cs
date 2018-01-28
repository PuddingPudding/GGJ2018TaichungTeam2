using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UFO_control : MonoBehaviour
{

    public float spawnRate = 1.5f;
    public float firstBorn = 0.5f;
    public GameObject bulletCandidate;
    public GameObject[] bulletDirection;
  

    void Start()
    {
        InvokeRepeating("bulletGenerate", firstBorn, spawnRate);
        
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
        }
    }

}
