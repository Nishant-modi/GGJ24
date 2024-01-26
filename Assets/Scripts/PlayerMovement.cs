using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerL;
    public Transform ForcePoint;
    public float speed = 1f;
    private Vector3 horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = new Vector3(-1,0,0);
            Debug.Log("Left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = new Vector3(1, 0, 0);
            Debug.Log("Right");
        }
        else
        {
            horizontal = new Vector3(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        ApplyForce(PlayerL, horizontal);
    }

    public void ApplyForce(Rigidbody2D rb, Vector3 direction)
    {
        Vector3 pos = ForcePoint.position;
        rb.AddForceAtPosition(direction * speed * 10,pos);
    }
}
