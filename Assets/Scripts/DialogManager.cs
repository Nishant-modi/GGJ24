using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomInSize = 5f;  // Adjust the zoom-in size
    public float zoomOutSize = 10f;  // Adjust the zoom-out size

    public void StartDialog()
    {
        StartCoroutine(DialogCoroutine());
    }

    private IEnumerator DialogCoroutine()
    {

        Camera.main.orthographicSize = zoomInSize;

        // Start dialog here (you can call your dialog system here)

        Camera.main.orthographicSize = zoomOutSize;

        yield return null;
    }
}
