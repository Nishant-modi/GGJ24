using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] EventReference FootstepsEvent;
    [SerializeField] EventReference BGTheme;
    [SerializeField] float rate;
    [SerializeField] GameObject player;
    PlayerMovement pm;

    float time;

    private void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayBGTheme();
        }
        
    }
    public void PlayFootstep()
    {
        RuntimeManager.PlayOneShotAttached(FootstepsEvent, player);
    }

    public void PlayBGTheme()
    {
        RuntimeManager.PlayOneShot(BGTheme);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(pm!=null)
        {
            if (pm.isWalking)
            {
                if (time >= rate)
                {
                    PlayFootstep();
                    time = 0;
                }
            }
        }
        
    }
}
