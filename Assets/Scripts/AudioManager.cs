using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] EventReference FootstepsEvent;
    [SerializeField] float rate;
    [SerializeField] GameObject player;
    PlayerMovement pm;

    float time;

    private void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }
    public void PlayFootstep()
    {
        RuntimeManager.PlayOneShotAttached(FootstepsEvent, player);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(pm.isWalking)
        {
            if(time>=rate)
            {
                PlayFootstep();
                time = 0;
            }
        }
    }
}
