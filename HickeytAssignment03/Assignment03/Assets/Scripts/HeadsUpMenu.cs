using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadsUpMenu : MonoBehaviour
{
    public Text lives;
    public Text playerName;
    public Text score;

    public void Start()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        lives.text = "Lives: " + PlayerPrefs.GetInt("lives").ToString();
        playerName.text = PlayerPrefs.GetString("name");
    }
}
