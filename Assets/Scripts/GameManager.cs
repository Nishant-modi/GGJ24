using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject nextLevelUI;
    public GameObject gameLoseUI;
    public GameObject Player;
    public DialogueManager dm;

    //public GameObject entryDoor;
    public bool levelComplete;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void LevelDone()
    {
        if (levelComplete)
        {
            
            if(dm.sceneChange)
            {

            }
            nextLevelUI.SetActive(true);
        }
        else
        {
            Debug.Log("Could'nt get shit done");
        }

    }

    public void GameLose()
    {
        //Death animation
        gameLoseUI.SetActive(true);
    }

    public void dialogueStart()
    {
        dm.StartDialogue();
    }

}
