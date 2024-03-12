using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    [SerializeField]
    
    public LevelManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            gameManager.PlayerPickUpCoins(other);
        }
    }
}
