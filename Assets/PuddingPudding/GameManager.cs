using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Collider2D chargingArea1P;
    private SpriteRenderer sprite1P;
    public p1_control p1Control;
    public Collider2D chargingArea2P;
    private SpriteRenderer sprite2P;
    public p2_control p2Control;
    public Color chargingColor;
    private Color originColor;
    public float transformTime = 0.4f;
    public float energyMax = 100;
    private float currentEnergy;
    public float energyLostSpeed = 20;
    public float energyChargeSpeed = 10;
    private bool charging = false;
    public Image energyBar;
    private bool isGaming = false;
    public GameObject gameOverText;

    // Use this for initialization
    void Start()
    {
        isGaming = true;
        gameOverText.SetActive(false);
        currentEnergy = energyMax;
        sprite1P = chargingArea1P.GetComponent<SpriteRenderer>();
        sprite2P = chargingArea2P.GetComponent<SpriteRenderer>();
        originColor = sprite1P.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (p1Control == null || p2Control == null)
        {
            isGaming = false;
            Time.timeScale = 0; //一但有任何一個玩家死掉，就把時間暫停
            gameOverText.SetActive(true);
        }

        if (isGaming)
        {
            if (chargingArea1P.IsTouching(chargingArea2P))
            {
                currentEnergy += energyChargeSpeed * Time.deltaTime;
                if (currentEnergy > energyMax)
                {
                    currentEnergy = energyMax;
                }
                if (!charging)
                {
                    charging = true;
                    DOTween.To(() => sprite1P.color, x => sprite1P.color = x, chargingColor, transformTime);
                    DOTween.To(() => sprite2P.color, x => sprite2P.color = x, chargingColor, transformTime);
                }
            }
            else
            {
                currentEnergy -= energyLostSpeed * Time.deltaTime;
                if (currentEnergy < 0)
                {
                    currentEnergy = 0;
                }
                if (charging)
                {
                    charging = false;
                    DOTween.To(() => sprite1P.color, x => sprite1P.color = x, originColor, transformTime);
                    DOTween.To(() => sprite2P.color, x => sprite2P.color = x, originColor, transformTime);
                }
            }

            if (currentEnergy <= 0)
            {
                p1Control.Suicide();
                p2Control.Suicide();
            }
        }


        energyBar.fillAmount = currentEnergy / energyMax;

        
    }
}
