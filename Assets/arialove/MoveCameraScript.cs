using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{

    public float readyTime; //開始延遲時間
    public float moveSpeed; //前進速度
    Vector3 origin;

    public float moveUpSpeed; //向上移動速度
    public float moveDownSpeed; //向下移動速度
    public bool moveUp;
    public bool moveDown;
    public bool gameEnd = false;
    public Collider2D endingPoint;
    public Collider2D border;

    // Use this for initialization
    void Start()
    {
        origin = this.transform.position;
    }

    public void Reset()
    {
        gameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (readyTime >= 0)
        {
            readyTime -= Time.deltaTime;
        }
        else if (!gameEnd)
        {
            this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed;
        }

        if (moveUp)
        {
            this.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * moveUpSpeed;
        }

        if (moveDown)
        {
            this.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveDownSpeed;
        }

        if (border.IsTouching(endingPoint) && !gameEnd)
        {
            //在camera邊界碰到結束點的時候就會進入結束事件，然而這裡這樣寫的一個問題是當我從外面扔物件進欄位時，
            //camera本身周遭帶有四個box collider，而這邊只需要其中一個，在這種時候Unity就會預設去抓第一個
            //解決方法-調整camera上的border之中box collider群組的順序
            Debug.Log("完成~!");
            gameEnd = true;
            this.transform.DOMoveX(this.transform.position.x + 7, 3.5f);
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
