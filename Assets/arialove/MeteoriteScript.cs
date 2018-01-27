using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteScript : MonoBehaviour {

    //隕石不會分裂版本

    public float rotateSpeed; //旋轉速度
    public GameObject candidate; //會分裂版本的候選人

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.eulerAngles += new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.G)) //測試爆炸後
        {
            MeteoriteExplode();
        }

    }

    public void MeteoriteExplode() //隕石爆炸分裂
    {
        Instantiate(candidate, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
