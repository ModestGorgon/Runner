using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointsText;
    public PlayerScript playerScript;

    public void Setup()
    {
        playerScript = playerScript.GetComponent<PlayerScript>();
        gameObject.SetActive(true);
        pointsText.text = "Your score is: " + GetComponent<CoinCount>().score.ToString();
       


    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");


    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }

}
