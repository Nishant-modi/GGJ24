using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabsFlower : MonoBehaviour
{
    private Vector3 oldPosition;
    private GrabObject go;

    private void Start()

    {
        go = FindObjectOfType<GrabObject>();
        oldPosition = gameObject.transform.position;
    }
    void Update()
    {
        if(gameObject.transform.position.x > oldPosition.x  + 3f || gameObject.transform.position.x < oldPosition.x -3f)
        {
            gameObject.SetActive(false);
            go.ObjectCollected();
            Debug.Log("taken flower");
        }
    }
    
    
}
