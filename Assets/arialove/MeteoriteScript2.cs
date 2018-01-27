using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteScript2 : MonoBehaviour {

    //隕石分裂版本

    public float rotateSpeed; //旋轉速度
    public float meteoriteSpeed; //隕石飛出去速度
    Vector3 flyDirection; //隕石塊飛出去方向
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

        childTransform.eulerAngles += new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime;
    }

    private void DestroyMeteorite()
    {
        Destroy(this.gameObject);
    }

}
