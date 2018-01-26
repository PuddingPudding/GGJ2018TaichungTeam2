using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_control : MonoBehaviour
{

    public float forceValue;
    private Rigidbody2D rigidbody2D = null;
    public float maxSpeed = 7;
    // Use this for initialization
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force2D = Vector2.zero;

       
        if (Input.GetKey(KeyCode.W))
        {
            force2D.y += forceValue;
        }
        if (Input.GetKey(KeyCode.S))
        {
            force2D.y -= forceValue;
        }
        if (Input.GetKey(KeyCode.A))
        {
            force2D.x -= forceValue;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force2D.x += forceValue;
        }

        

        rigidbody2D.AddForce(force2D);
        if (rigidbody2D.velocity.magnitude >= maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed; /*單位為一固定方向給他最大速度*/
        }
        Debug.Log(rigidbody2D.velocity.magnitude);


    }
}


