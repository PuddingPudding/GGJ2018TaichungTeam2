using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UFO_control : MonoBehaviour
{

    public float spawnRate = 0.5f;
    public float lastSpawnTime = 0.0f;
    public GameObject bulletCandidate;
    public float currentTime = 0.0f;
    private float bulletOffset = 1.2f;

    void Start()
    {

    }


   

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if((currentTime - lastSpawnTime) > spawnRate)
        {
            Vector3 pos = gameObject.transform.position + new Vector3(-2.0f, 0, 0);
            Instantiate(bulletCandidate, pos, gameObject.transform.rotation);
            lastSpawnTime = currentTime;
        }
            
    }

   
}
