using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    public void DoClick()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene("MainScene");
    }
}
