using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
   public Rigidbody2D rb;
    public BoxCollider2D cd;
    public LayerMask playerLayer;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        cd.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.isKinematic = false;
            rb.mass = 1.5f;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //rb.isKinematic = true;
            //Destroy(rb);
            Destroy(cd);
        }
    }
}
