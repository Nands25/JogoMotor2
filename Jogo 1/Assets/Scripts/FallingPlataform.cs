using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallingTime;
    public float respawnTime = 5f;
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
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
    }

    void ReaparecerPlataforma()
    {
        // Reseta a posição da plataforma para a posição inicial
        transform.position = initialPosition;

        // Reativa a física e a colisão da plataforma
        target.enabled = true;
        boxColl.isTrigger = false;
    }
    
}
