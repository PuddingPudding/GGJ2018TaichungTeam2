using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMove : MonoBehaviour {

	public float MaxY = 1.0f;
    public float MinY = -1.0f;
    public float MaxX = 1.0f;
    public float MinX = -1.0f;
    public float spawnRate = 2.5f;
    public float firstBorn = 4.0f;
    private Vector3 original_location;

    // Use this for initialization
    void Start () {
        original_location = this.transform.position;
        InvokeRepeating("autoMOve", firstBorn, spawnRate);
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    void autoMOve ()
    {
        this.transform.position = original_location;
        this.transform.position += new Vector3(UnityEngine.Random.Range(MinX, MaxX), UnityEngine.Random.Range(MinY, MaxY), 0);
    }
 
}
