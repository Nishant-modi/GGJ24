using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalance : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D PlayerU;
    public Transform BalancePoint;
    public float speed = 1f;
    private Vector3 horizontal;

    [Header("Crouch")]
    public HingeJoint2D hjU;
    public Vector2 standingAnchor;
    public Vector2 crouchingAnchor;
    public Vector2 standingConnectedAnchor;
    public Vector2 crouchingConnectedAnchor;
    // Start is called before the first frame update
    void Start()
    {
        standingAnchor = hjU.anchor;
        standingConnectedAnchor = hjU.connectedAnchor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = new Vector3(-1, 0, 0);
            Debug.Log("Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = new Vector3(1, 0, 0);
            Debug.Log("Right");
        }
        else
        {
            horizontal = new Vector3(0, 0, 0);
        }

        horizontal = new Vector3(Input.GetAxis("PlayerUBalance"), 0, 0);


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetButton("PlayerLCrouch"))
        {
            hjU.enableCollision = false;
            hjU.anchor = crouchingAnchor;
            Debug.Log("Crouch");
            hjU.connectedAnchor = crouchingConnectedAnchor;
            hjU.enableCollision = true;
        }
        else
        {
            hjU.enableCollision = false;
            hjU.anchor = standingAnchor;
            hjU.connectedAnchor = standingConnectedAnchor;
            hjU.enableCollision = true;
        }
    }

    private void FixedUpdate()
    {
        ApplyForce(PlayerU, horizontal);
    }

    public void ApplyForce(Rigidbody2D rb, Vector3 direction)
    {
        Vector3 pos = BalancePoint.position;
        rb.AddForceAtPosition(direction * speed * 10, pos);
    }
}
