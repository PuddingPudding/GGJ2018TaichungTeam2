using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    private SpriteRenderer[] thunderArray;
    public Color transformColor;
    public float blinkTime = 0.8f;
    private bool isBlinking = false;

    // Use this for initialization
    void Start()
    {
        thunderArray = GetComponentsInChildren<SpriteRenderer>();
        
        for(int i = 1; i < thunderArray.Length; i++)
        {
            thunderArray[i].color = Color.clear;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = this.GetComponent<Collider2D>();
        if (collider.IsTouchingLayers(LayerMask.GetMask("Sensor")))
        {
            if(!isBlinking)
            {
                isBlinking = true;
                Blink(thunderArray[Random.Range(1, thunderArray.Length)]);
                Blink(thunderArray[Random.Range(1, thunderArray.Length)]);
                Blink(thunderArray[Random.Range(1, thunderArray.Length)]);
                Blink(thunderArray[Random.Range(1, thunderArray.Length)]);
            }
        }
    }

    void Blink(SpriteRenderer spriteRenderer)
    {
        DOTween.To(() => spriteRenderer.color, x => spriteRenderer.color = x, transformColor, blinkTime/2).OnComplete(() =>
        {
            DOTween.To(() => spriteRenderer.color, x => spriteRenderer.color = x, Color.clear, blinkTime / 2);
            isBlinking = false;
        });
    }
}
