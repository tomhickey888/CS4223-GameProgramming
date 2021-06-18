using System;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText1;
    public Text highScoreNameText1;

    public Text highScoreText2;
    public Text highScoreNameText2;

    public Text highScoreText3;
    public Text highScoreNameText3;

    public Text highScoreText4;
    public Text highScoreNameText4;

    public Text highScoreText5;
    public Text highScoreNameText5;

    public Text highScoreText6;
    public Text highScoreNameText6;

    public Text highScoreText7;
    public Text highScoreNameText7;

    public Text highScoreText8;
    public Text highScoreNameText8;

    public Text highScoreText9;
    public Text highScoreNameText9;

    public Text highScoreText10;
    public Text highScoreNameText10;

    private int score;
    private string name;


    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        name = PlayerPrefs.GetString("name");

        if (PlayerPrefs.HasKey("highScore1"))
            highScoreText1.text = PlayerPrefs.GetInt("highScore1").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreText1.text = PlayerPrefs.GetInt("highScore1").ToString();
        }

        if (PlayerPrefs.HasKey("highName1"))
            highScoreNameText1.text = PlayerPrefs.GetString("highName1");
        else
        {
            PlayerPrefs.SetString("highName1", "Empty");
            highScoreNameText1.text = PlayerPrefs.GetString("highName1");
        }

        if (PlayerPrefs.HasKey("highScore2"))
            highScoreText2.text = PlayerPrefs.GetInt("highScore2").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore2", 0);
            highScoreText2.text = PlayerPrefs.GetInt("highScore2").ToString();
        }

        if (PlayerPrefs.HasKey("highName2"))
            highScoreNameText2.text = PlayerPrefs.GetString("highName2");
        else
        {
            PlayerPrefs.SetString("highName2", "Empty");
            highScoreNameText2.text = PlayerPrefs.GetString("highName2");
        }

        if (PlayerPrefs.HasKey("highScore3"))
            highScoreText3.text = PlayerPrefs.GetInt("highScore3").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore3", 0);
            highScoreText3.text = PlayerPrefs.GetInt("highScore3").ToString();
        }

        if (PlayerPrefs.HasKey("highName3"))
            highScoreNameText3.text = PlayerPrefs.GetString("highName3");
        else
        {
            PlayerPrefs.SetString("highName3", "Empty");
            highScoreNameText3.text = PlayerPrefs.GetString("highName3");
        }

        if (PlayerPrefs.HasKey("highScore4"))
            highScoreText4.text = PlayerPrefs.GetInt("highScore4").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore4", 0);
            highScoreText4.text = PlayerPrefs.GetInt("highScore4").ToString();
        }

        if (PlayerPrefs.HasKey("highName5"))
            highScoreNameText5.text = PlayerPrefs.GetString("highName5");
        else
        {
            PlayerPrefs.SetString("highName4", "Empty");
            highScoreNameText4.text = PlayerPrefs.GetString("highName4");
        }

        if (PlayerPrefs.HasKey("highScore5"))
            highScoreText5.text = PlayerPrefs.GetInt("highScore5").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore5", 0);
            highScoreText5.text = PlayerPrefs.GetInt("highScore5").ToString();
        }

        if (PlayerPrefs.HasKey("highName5"))
            highScoreNameText5.text = PlayerPrefs.GetString("highName5");
        else
        {
            PlayerPrefs.SetString("highName5", "Empty");
            highScoreNameText5.text = PlayerPrefs.GetString("highName5");
        }

        if (PlayerPrefs.HasKey("highScore6"))
            highScoreText6.text = PlayerPrefs.GetInt("highScore6").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore6", 0);
            highScoreText6.text = PlayerPrefs.GetInt("highScore6").ToString();
        }

        if (PlayerPrefs.HasKey("highName6"))
            highScoreNameText6.text = PlayerPrefs.GetString("highName6");
        else
        {
            PlayerPrefs.SetString("highName6", "Empty");
            highScoreNameText6.text = PlayerPrefs.GetString("highName6");
        }

        if (PlayerPrefs.HasKey("highScore7"))
            highScoreText7.text = PlayerPrefs.GetInt("highScore7").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore7", 0);
            highScoreText7.text = PlayerPrefs.GetInt("highScore7").ToString();
        }

        if (PlayerPrefs.HasKey("highName7"))
            highScoreNameText7.text = PlayerPrefs.GetString("highName7");
        else
        {
            PlayerPrefs.SetString("highName7", "Empty");
            highScoreNameText7.text = PlayerPrefs.GetString("highName7");
        }

        if (PlayerPrefs.HasKey("highScore8"))
            highScoreText8.text = PlayerPrefs.GetInt("highScore8").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore8", 0);
            highScoreText8.text = PlayerPrefs.GetInt("highScore8").ToString();
        }

        if (PlayerPrefs.HasKey("highName8"))
            highScoreNameText8.text = PlayerPrefs.GetString("highName8");
        else
        {
            PlayerPrefs.SetString("highName8", "Empty");
            highScoreNameText8.text = PlayerPrefs.GetString("highName8");
        }

        if (PlayerPrefs.HasKey("highScore9"))
            highScoreText9.text = PlayerPrefs.GetInt("highScore9").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore9", 0);
            highScoreText9.text = PlayerPrefs.GetInt("highScore9").ToString();
        }

        if (PlayerPrefs.HasKey("highName9"))
            highScoreNameText9.text = PlayerPrefs.GetString("highName9");
        else
        {
            PlayerPrefs.SetString("highName9", "Empty");
            highScoreNameText9.text = PlayerPrefs.GetString("highName9");
        }

        if (PlayerPrefs.HasKey("highScore10"))
            highScoreText10.text = PlayerPrefs.GetInt("highScore10").ToString();
        else
        {
            PlayerPrefs.SetInt("highScore10", 0);
            highScoreText10.text = PlayerPrefs.GetInt("highScore10").ToString();
        }

        if (PlayerPrefs.HasKey("highName10"))
            highScoreNameText10.text = PlayerPrefs.GetString("highName10");
        else
        {
            PlayerPrefs.SetString("highName10", "Empty");
            highScoreNameText10.text = PlayerPrefs.GetString("highName10");
        }

        if (score > Convert.ToInt32(highScoreText1.text))
        {
            highScoreText1.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", score);
            highScoreNameText1.text = name;
            PlayerPrefs.SetString("highName1", name);
        }

        else if (score > Convert.ToInt32(highScoreText2.text))
        {
            highScoreText2.text = score.ToString();
            PlayerPrefs.SetInt("highScore2", score);
            highScoreNameText2.text = name;
            PlayerPrefs.SetString("highName2", name);
        }

        else if (score > Convert.ToInt32(highScoreText3.text))
        {
            highScoreText3.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreNameText3.text = name;
            PlayerPrefs.SetString("highName3", name);
        }

        else if (score > Convert.ToInt32(highScoreText4.text))
        {
            highScoreText4.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreNameText4.text = name;
            PlayerPrefs.SetString("highName4", name);
        }

        else if (score > Convert.ToInt32(highScoreText5.text))
        {
            highScoreText5.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreNameText5.text = name;
            PlayerPrefs.SetString("highName5", name);
        }

        else if (score > Convert.ToInt32(highScoreText6.text))
        {
            highScoreText6.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreNameText6.text = name;
            PlayerPrefs.SetString("highName6", name);
        }

        else if (score > Convert.ToInt32(highScoreText7.text))
        {
            highScoreText7.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreNameText7.text = name;
            PlayerPrefs.SetString("highName7", name);
        }

        else if (score > Convert.ToInt32(highScoreText8.text))
        {
            highScoreText8.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreNameText8.text = name;
            PlayerPrefs.SetString("highName8", name);
        }

        else if (score > Convert.ToInt32(highScoreText9.text))
        {
            highScoreText9.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreNameText9.text = name;
            PlayerPrefs.SetString("highName9", name);
        }

        else if (score > Convert.ToInt32(highScoreText10.text))
        {
            highScoreText10.text = score.ToString();
            PlayerPrefs.SetInt("highScore1", 0);
            highScoreNameText10.text = name;
            PlayerPrefs.SetString("highName10", name);
        }
    }

    public void clearScores()
    {
        PlayerPrefs.SetInt("highScore1", 0);
        PlayerPrefs.SetString("highName1", "Empty");
        PlayerPrefs.SetInt("highScore2", 0);
        PlayerPrefs.SetString("highName2", "Empty");
        PlayerPrefs.SetInt("highScore3", 0);
        PlayerPrefs.SetString("highName3", "Empty");
        PlayerPrefs.SetInt("highScore4", 0);
        PlayerPrefs.SetString("highName4", "Empty");
        PlayerPrefs.SetInt("highScore5", 0);
        PlayerPrefs.SetString("highName5", "Empty");
        PlayerPrefs.SetInt("highScore6", 0);
        PlayerPrefs.SetString("highName6", "Empty");
        PlayerPrefs.SetInt("highScore7", 0);
        PlayerPrefs.SetString("highName7", "Empty");
        PlayerPrefs.SetInt("highScore8", 0);
        PlayerPrefs.SetString("highName8", "Empty");
        PlayerPrefs.SetInt("highScore9", 0);
        PlayerPrefs.SetString("highName9", "Empty");
        PlayerPrefs.SetInt("highScore10", 0);
        PlayerPrefs.SetString("highName10", "Empty");

        PlayerPrefs.Save();
    }
}
