using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour {

    public float readyTime; //開始延遲時間
    public float moveSpeed; //前進速度
    Vector3 origin;

    public float moveUpSpeed; //向上移動速度
    public float moveDownSpeed; //向下移動速度
    public bool moveUp;
    public bool moveDown;
    private bool gameEnd = false;
    public Collider2D endingPoint;
    public Collider2D border;

    // Use this for initialization
    void Start () {
        origin = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if(readyTime >= 0)
        {
            readyTime -= Time.deltaTime;
        }
        else if(!gameEnd)
        {
            this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed;
        }

        if(moveUp)
        {
            this.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * moveUpSpeed;
        }

        if(moveDown)
        {
            this.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveDownSpeed;
        }
        
        if(border.IsTouching(endingPoint) )
        {
            gameEnd = true;
            Vector2 endingPosition = this.transform.position + new Vector3(7,0,0);
            this.transform.DOMove(endingPosition, 3.5f);
        }
    }

    public void MoveUpOn()
    {
        moveUp = true;
    }

    public void MoveUpOff()
    {
        moveUp = false;
    }

    public void MoveDownOn()
    {
        moveDown = true;
    }

    public void MoveDownOff()
    {
        moveDown = false;
    }
}
