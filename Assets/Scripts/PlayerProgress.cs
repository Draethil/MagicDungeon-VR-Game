using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public int DeathCount = 0;
    public int CoinsCount = 0;
    public float TimePast = 0;

    public static PlayerProgress Singleton;

    // Start is called before the first frame update
    void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(Singleton);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerProgressReset()
    {
        CoinsCount = 0;
        DeathCount = 0;
        TimePast = 0;
    }
}
