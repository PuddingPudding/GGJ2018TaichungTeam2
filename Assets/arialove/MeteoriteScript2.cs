using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteScript2 : MonoBehaviour {

    public bool rotate;
    public float rotateSpeed;
    public float meteoriteSpeed;
    Vector3 flyDirection;
    public Transform childTransform;

    // Use this for initialization
    void Start()
    {
        flyDirection = this.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += flyDirection * meteoriteSpeed * Time.deltaTime;

        if (rotate)
        {
            childTransform.eulerAngles += new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime;
        }
    }

}
