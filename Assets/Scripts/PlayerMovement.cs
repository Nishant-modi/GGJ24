using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D playerL;
    public Transform forcePoint;
    public float speed = 1f;

    [Header("Crouch")]
    public BoxCollider2D bcL;
    public Vector2 standingSize;
    public Vector2 crouchingSize;
    public Vector2 standingOffset;
    public Vector2 crouchingOffset;

    public Animator animatorL;
    private Vector3 horizontal;

    
    void Start()
    {
        standingSize = bcL.size;
        standingOffset = bcL.offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = new Vector3(-1,0,0);
           // Debug.Log("Left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = new Vector3(1, 0, 0);
            //Debug.Log("Right");
        }
        else
        {
            horizontal = new Vector3(0, 0, 0);
        }

        
        horizontal = new Vector3(Input.GetAxis("PlayerLHorizontal"), 0, 0);

        if (horizontal == Vector3.zero)
        {
            animatorL.SetBool("isRunning", false);
        }
        else
        {
            animatorL.SetBool("isRunning", true);
        }


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetButton("PlayerLCrouch"))
        {
            bcL.size = crouchingSize;
            //Debug.Log("Crouch");
            bcL.offset = crouchingOffset;
            animatorL.SetBool("isCrouching", true);
        }
        else
        {
            bcL.size = standingSize;
            bcL.offset = standingOffset;
            animatorL.SetBool("isCrouching", false);
        }
    }

    private void FixedUpdate()
    {
        ApplyForce(playerL, horizontal);
    }

    public void ApplyForce(Rigidbody2D rb, Vector3 direction)
    {
        Vector3 pos = forcePoint.position;
        rb.AddForceAtPosition(direction * speed * 10,pos);
    }
}
