using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private HingeJoint2D hjGrab;
    private Collider2D grabbableObject;
    [SerializeField] private Transform vicinityCheck;
    [SerializeField] private LayerMask grabbableObjectLayer;
    private bool isGrabbing;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && IsInVicinity() && hjGrab == null)
        {
            isGrabbing = true;
            Debug.Log("is Grabbing");
            grabbableObject = Physics2D.OverlapCircle(vicinityCheck.position, 1f, grabbableObjectLayer);
            hjGrab = gameObject.AddComponent<HingeJoint2D>();
            hjGrab.connectedBody = grabbableObject.gameObject.GetComponent<Rigidbody2D>();
        }
        if(Input.GetKeyUp(KeyCode.G) || !IsInVicinity())
        {

            Destroy(hjGrab);
            isGrabbing = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    public bool IsInVicinity()
    {
        //Collider2D temp = Physics2D.OverlapCircle(vicinityCheck.position, 1f, grabbableObjectLayer);
        return Physics2D.OverlapCircle(vicinityCheck.position, 1f, grabbableObjectLayer);
    }
}
