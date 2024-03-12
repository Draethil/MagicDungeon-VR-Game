using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public GameObject GamePlayer;
    //[SerializeField] Transform StartPosition;
    [SerializeField] Text countText;
    [SerializeField] Text deathText;
    [SerializeField] Transform respawnTransform;
    [SerializeField] Transform cheatSpawn;

    public static LevelManager Singleton;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
        PlayerProgress.Singleton.PlayerProgressReset();

        //GamePlayer = FindObjectOfType<playermovement>();
      
        UpdatePointText();
    }

    private void Update()
    {
        UpdateDeathText();
        UpdatePointText();
    }

    public void CompleteLevel()
    {
        Debug.Log("Level Completed!");
        SceneManager.LoadScene("EndScene");
    }

    public void PlayerPickUpCoins(Collider other)
    {

        Destroy(other.gameObject);
        PlayerProgress.Singleton.CoinsCount++;

    }

    public void PlayerDeath()
    {

        GamePlayer.gameObject.SetActive(false);
        GamePlayer.transform.position = respawnTransform.position;
        GamePlayer.gameObject.SetActive(true);

        PlayerProgress.Singleton.DeathCount++;

    }

    public void cheatTeleportPlayer()
    {
        GamePlayer.gameObject.SetActive(false);
        GamePlayer.transform.position = cheatSpawn.position;
        GamePlayer.gameObject.SetActive(true);
    }

    public void UpdatePointText()
    {
        countText.text = "Coins: " + PlayerProgress.Singleton.CoinsCount.ToString();
    }

    public void UpdateDeathText(){
        deathText.text = "Deaths: " + PlayerProgress.Singleton.DeathCount.ToString();
    }
}
