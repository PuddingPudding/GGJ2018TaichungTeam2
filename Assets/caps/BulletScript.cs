using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Vector3 bulletDirection;
    public float speed = 4;
    public float firstBorn = 0.5f;
    public float spawnRate = 1.2f;

    void Start()
    {
        InvokeRepeating("bulletGenerate", firstBorn, spawnRate);

    }





    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = this.transform.right * speed;
        gameObject.transform.position += bulletDirection;
        InvokeRepeating("Suicide", 3.0f, 3.0f);
    }

    public void Suicide()
    {
        Destroy(gameObject); //消滅物件本身
    }
}

