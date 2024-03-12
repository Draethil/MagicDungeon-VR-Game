using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F4))
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                LevelManager.Singleton.CompleteLevel();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerProgress.Singleton.PlayerProgressReset();
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                LevelManager.Singleton.PlayerDeath();
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                LevelManager.Singleton.cheatTeleportPlayer();
            }
        }
    }
}
