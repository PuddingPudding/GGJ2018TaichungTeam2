using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeteoriteScript : MonoBehaviour {

    //隕石不會分裂版本

    public float rotateSpeed; //旋轉速度
    public GameObject candidate; //會分裂版本的候選人
    public Color changeColor; //變化後的顏色
    public float changeTime; //變化的時間

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
        //要爆炸時隕石由原本顏色變成設定顏色後爆炸 並消滅自己本身
        DOTween.To(() => this.GetComponent<SpriteRenderer>().color, x => this.GetComponent<SpriteRenderer>().color = x, changeColor, changeTime).OnComplete (() =>
        {
            Instantiate(candidate, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        } );
    }

}
