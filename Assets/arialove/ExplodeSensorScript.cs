using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSensorScript : MonoBehaviour {

    public float explodeTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("explode!");
        if(other.tag == "Border") //tag為border碰到後觸發
        {
            
            this.GetComponentInParent<MeteoriteScript>().Invoke("MeteoriteExplode", explodeTime);
        }
    }
}
