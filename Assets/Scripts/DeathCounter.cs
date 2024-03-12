using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    [SerializeField]
    
    public LevelManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameManager.PlayerDeath();
        }
    }
}
