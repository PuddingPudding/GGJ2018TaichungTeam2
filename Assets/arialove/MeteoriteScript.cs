using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteScript : MonoBehaviour {

    public float rotateSpeed;
    public GameObject candidate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.eulerAngles += new Vector3(0,0,1) * rotateSpeed *  Time.deltaTime;

        if(Input.GetKey(KeyCode.G))
        {
            MeteoriteExplode();
        }

    }

    public void MeteoriteExplode()
    {
        Instantiate(candidate, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
