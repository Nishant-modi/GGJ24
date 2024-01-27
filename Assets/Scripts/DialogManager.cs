using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    //public Camera mainCamera;
    [Header("Camera Controls")]
    public FollowCamera fc;
    public GameObject target1;
    public GameObject target2;
    public Vector3 offset1;
    public Vector3 offset2;
    public float zoomInSize;  // Adjust the zoom-in size
    public float zoomOutSize;  // Adjust the zoom-out size

    [Header("Dialogue Controls")]
    public Queue<string> sentences;

    private void Start()
    {
        fc = FindObjectOfType<FollowCamera>();
        StartCoroutine(DialogCoroutine());

        sentences = new Queue<string>();
    }

    public void StartDialog()
    {
        StartCoroutine(DialogCoroutine());
    }

    private IEnumerator DialogCoroutine()
    {
        fc.orthographicSize = zoomInSize;

        fc.target1 = target2;
        fc.offset = offset2;
        
        // Start dialog here (you can call your dialog system here)

        yield return new WaitForSeconds(3f);

        fc.target1 = target1;
        fc.offset = offset1;

        //fc.orthographicSize = zoomOutSize;

        

        yield return null;
    }
}
