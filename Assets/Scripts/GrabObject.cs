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
    public Animator animatorU;
    private float isGrabbing;
    public GameObject grabObject;

    public GameObject popcornsprite;

    private PlayerMovement pm;

    
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        grabObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G) && IsGrabbableInVicinity() && hjGrab == null)
        if (Input.GetButton("PlayerUGrab") && IsGrabbableInVicinity() && hjGrab == null)
        {
            
            Debug.Log("is Grabbing");
            grabbableObject = Physics2D.OverlapCircle(vicinityCheck.position, 2f, grabbableObjectLayer);
            hjGrab = gameObject.AddComponent<HingeJoint2D>();
            hjGrab.connectedBody = grabbableObject.gameObject.GetComponent<Rigidbody2D>();
            
            if(grabbableObject.transform.position.x<gameObject.transform.position.x)
            {
                isGrabbing = -1;

            }
            else
            {
                isGrabbing = 1;
            }

            animatorU.SetFloat("isGrabbing", isGrabbing);
        }
        if (Input.GetButtonUp("PlayerUGrab") || !IsGrabbableInVicinity())
        {
            if(grabbableObject!=null)
            {
                //grabbableObject.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            
            Destroy(hjGrab);
            isGrabbing = 0;
            animatorU.SetFloat("isGrabbing", isGrabbing);
        }

        if (Input.GetButton("PlayerUGrab") && IsCollectibleInVicinity())
        {
            collectibleObject = Physics2D.OverlapCircle(vicinityCheck.position, 2f, collectibleObjectLayer);
            if(collectibleObject.gameObject.tag == "Popcorn")
            {
                popcornsprite.SetActive(true);
            }
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
        return Physics2D.OverlapCircle(vicinityCheck.position, 2f, grabbableObjectLayer);
    }

    public bool IsCollectibleInVicinity()
    {
        //Collider2D temp = Physics2D.OverlapCircle(vicinityCheck.position, 1f, grabbableObjectLayer);
        return Physics2D.OverlapCircle(vicinityCheck.position, 2f, collectibleObjectLayer);
    }

    public void ObjectCollected()
    {
        pm.objectCollected = true;
        Debug.Log("Object Collected");
        grabObject.SetActive(true);
        //isGrabbing = false;
    }
}
