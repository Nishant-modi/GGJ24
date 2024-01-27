using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private HingeJoint2D hjGrab;
    private Collider2D grabbableObject;
    private Collider2D collectibleObject;
    [SerializeField] private Transform vicinityCheck;
    [SerializeField] private LayerMask grabbableObjectLayer;
    [SerializeField] private LayerMask collectibleObjectLayer;
    private bool isGrabbing;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && IsGrabbableInVicinity() && hjGrab == null)
        {
            isGrabbing = true;
            Debug.Log("is Grabbing");
            grabbableObject = Physics2D.OverlapCircle(vicinityCheck.position, 1f, grabbableObjectLayer);
            hjGrab = gameObject.AddComponent<HingeJoint2D>();
            hjGrab.connectedBody = grabbableObject.gameObject.GetComponent<Rigidbody2D>();
        }
        if (Input.GetKeyUp(KeyCode.G) || !IsGrabbableInVicinity())
        {

            Destroy(hjGrab);
            isGrabbing = false;
        }

        if (Input.GetKeyDown(KeyCode.G) && IsCollectibleInVicinity())
        {
            collectibleObject = Physics2D.OverlapCircle(vicinityCheck.position, 1f, collectibleObjectLayer);
            collectibleObject.gameObject.SetActive(false);
            ObjectCollected();
        }
    }

    private void FixedUpdate()
    {
        
    }

    public bool IsGrabbableInVicinity()
    {
        //Collider2D temp = Physics2D.OverlapCircle(vicinityCheck.position, 1f, grabbableObjectLayer);
        return Physics2D.OverlapCircle(vicinityCheck.position, 1f, grabbableObjectLayer);
    }

    public bool IsCollectibleInVicinity()
    {
        //Collider2D temp = Physics2D.OverlapCircle(vicinityCheck.position, 1f, grabbableObjectLayer);
        return Physics2D.OverlapCircle(vicinityCheck.position, 1f, collectibleObjectLayer);
    }

    public void ObjectCollected()
    {
        Debug.Log("Object Collected");
    }
}
