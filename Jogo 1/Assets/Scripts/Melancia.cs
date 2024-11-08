using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melancia : MonoBehaviour
{
    private SpriteRenderer sr;

    private CircleCollider2D circle;

    public GameObject Coletar;
    
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            Coletar.SetActive(true);
            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();
            
            Destroy(gameObject,0.25f);
        }
    }
}
