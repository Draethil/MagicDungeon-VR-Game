using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = PlayerProgress.Singleton.TimePast.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerProgress.Singleton.TimePast += Time.deltaTime;
        DisplayTime(PlayerProgress.Singleton.TimePast);
    }

    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textBox.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
