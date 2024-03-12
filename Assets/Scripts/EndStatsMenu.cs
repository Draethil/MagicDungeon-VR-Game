using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndStatsMenu : MonoBehaviour
{
    public Text countText;
    public Text deathText;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePointText();
        UpdateDeathText();
        DisplayTime(PlayerProgress.Singleton.TimePast);
    }

    public void UpdatePointText()
    {
        countText.text = "Coins: " + PlayerProgress.Singleton.CoinsCount.ToString();
    }

    public void UpdateDeathText()
    {
        deathText.text = "Deaths: " + PlayerProgress.Singleton.DeathCount.ToString();
    }

    public void RestartGame()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene("StartScene");
    }

    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
}
