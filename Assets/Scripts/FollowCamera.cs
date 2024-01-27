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
    public Vector3 minValues, maxValue;
    public float orthographicSize = 5.2f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
            mainCamera.orthographicSize = orthographicSize;
            target = (target1.transform.position);
            Vector3 targetPosition = new Vector3(target.x + offset.x, target.y + offset.y, -10f);
            Vector3 boundPosition = new Vector3(
               Mathf.Clamp(targetPosition.x, minValues.x, maxValue.x),
               Mathf.Clamp(targetPosition.y, minValues.y, maxValue.y),
               Mathf.Clamp(targetPosition.z, minValues.z, maxValue.z));

            transform.position = Vector3.SmoothDamp(transform.position, boundPosition, ref velocity, smoothTime);
        
    }


}
