using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public Text playerName;
    public Text lives;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = PlayerPrefs.GetString("name");
        lives.text = PlayerPrefs.GetInt("livesUsed").ToString();
        score.text = PlayerPrefs.GetInt("score").ToString();
    }
}
