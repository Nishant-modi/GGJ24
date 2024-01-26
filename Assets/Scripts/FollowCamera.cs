using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target1;
    //public GameObject target2;
    public Vector3 target;
    public Vector3 offset;
    public float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;


    void FixedUpdate()
    {
        target = (target1.transform.position);
        Vector3 targetPosition = new Vector3(target.x + offset.x, target.y + offset.y, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
