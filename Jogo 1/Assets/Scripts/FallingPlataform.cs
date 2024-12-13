using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallingTime;
    public float respawnTime;
    private TargetJoint2D target;
    private BoxCollider2D boxColl;
    private Vector3 initialPosition;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
        initialPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
            Invoke("ReaparecerPlataforma", respawnTime);
        }

    }
    void Falling()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
    }

    void ReaparecerPlataforma()
    {
        transform.position = initialPosition;
        target.enabled = true;
        boxColl.isTrigger = false;
    }
    
}
