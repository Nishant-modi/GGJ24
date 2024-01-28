using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;
    public bool sceneChange = false;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = false;
        dialogue1.SetActive(false);
        dialogue2.SetActive(false);
        gm = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        StartCoroutine(Dialogues());
    }

    IEnumerator Dialogues()
    {
        dialogue1.SetActive(true);

        yield return new WaitForSeconds(6f);

        dialogue1.SetActive(false);
        dialogue2.SetActive(true);

        yield return new WaitForSeconds(6f);
        sceneChange = true;
        gm.NextLevel();
        //return null;
    }
}
