using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    //public Camera mainCamera;
    [Header("Camera Controls")]
    public FollowCamera fc;
    public GameObject target1;
    public GameObject target2;
    public Vector3 offset1;
    public Vector3 offset2;
    public Vector3 defaultOffset;
    public float zoomInSize;  // Adjust the zoom-in size
    public float zoomOutSize;  // Adjust the zoom-out size

    [Header("Dialogue Controls")]
    //public Queue<string> sentences;
    public GameObject dialogue1;
    public GameObject dialogue2;

    private void Start()
    {
        fc = FindObjectOfType<FollowCamera>();
        StartCoroutine(DialogCoroutine());

        dialogue1.SetActive(false);
        dialogue2.SetActive(false);

        //sentences = new Queue<string>();
    }

    //public void StartDialogue(Dialogue dialogue)
    
        //StartCoroutine(DialogCoroutine());
    

    private IEnumerator DialogCoroutine()
    {
        fc.orthographicSize = zoomInSize;

        //if(SceneManager.GetActiveScene().name == "Level0")
        {
            fc.target1 = target1;
            fc.offset = offset1;

            yield return new WaitForSeconds(2f);

            dialogue1.SetActive(true);

            yield return new WaitForSeconds(6f);

            dialogue1.SetActive(false);

            yield return new WaitForSeconds(2f);

            fc.target1 = target2;
            fc.offset = offset2;

            yield return new WaitForSeconds(2f);

            dialogue2.SetActive(true);

            yield return new WaitForSeconds(6f);

            dialogue2.SetActive(false);
        }
        
        
        

        

        fc.orthographicSize = zoomOutSize;
        fc.offset = defaultOffset;

        

        yield return null;
    }
}
