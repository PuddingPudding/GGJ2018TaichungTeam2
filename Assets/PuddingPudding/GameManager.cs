using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Collider2D chargingArea1P;
    public Collider2D chargingArea2P;
    public float energyMax = 100;
    private float currentEnergy;
    public float energyLostSpeed = 20;
    public float energyChargeSpeed = 10;

    // Use this for initialization
    void Start()
    {
        currentEnergy = energyMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(chargingArea1P.IsTouching(chargingArea2P) && currentEnergy < energyMax)
        {
            currentEnergy += energyChargeSpeed * Time.deltaTime;
            if(currentEnergy > energyMax)
            {
                currentEnergy = energyMax;
            }
        }
        else
        {
            currentEnergy -= energyLostSpeed * Time.deltaTime;
            if(currentEnergy < 0)
            {
                currentEnergy = 0;
            }
        }
        Debug.Log("currentEnergy" + currentEnergy);
    }
}
