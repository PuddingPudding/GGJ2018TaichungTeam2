using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuBackgooundScript : MonoBehaviour {

    public Vector3 starPotition;
    public Vector3 endPotition;

    public float moveSpeed;

    public bool change;

    // Use this for initialization
    void Start () {
        this.transform.position = starPotition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(this.transform.position.x < endPotition.x && change)
        {
            RightMove();
        }

        if(this.transform.position.x > starPotition.x && !change)
        {
            LeftMove();
        }

        if(this.transform.position.x > endPotition.x)
        {
            change = false;
        }

        if(this.transform.position.x < starPotition.x)
        {
            change = true;
        }
    }

    public void RightMove()
    {
        this.transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
    }

    public void LeftMove()
    {
        this.transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
    }
}
