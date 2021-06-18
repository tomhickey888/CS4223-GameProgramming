using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    public Text highScoreNameText;
    public Text newHighScoreText;

    private int highScore;
    private string highScoreName;
    private int score;

    private bool newHighScore = false;

    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
            highScore = PlayerPrefs.GetInt("highScore");
        else
            highScore = 0;

        if (PlayerPrefs.HasKey("highScoreName"))
            highScoreName = PlayerPrefs.GetString("highScoreName");
        else
            highScoreName = "None";

        score = PlayerPrefs.GetInt("score");

        FindObjectOfType<Canvas>().GetComponent<PlayerSettings>().DisplayScore();
        FindObjectOfType<Canvas>().GetComponent<PlayerSettings>().DisplayName();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.SetString("highScoreName", name);
            highScore = PlayerPrefs.GetInt("highScore");
            highScoreName = PlayerPrefs.GetString("highScoreName");
            newHighScore = true;
        }

    }

    void displayHighScoreName()
    {
        highScoreNameText.text = highScoreName;
    }

    void displayNewHighScore()
    {
        if (newHighScore)
        {
            highScoreText.color = Color.yellow;
            FindObjectOfType<Canvas>().GetComponent<Animator>().SetTrigger("NewHighScore");
        }
    }

    void displayHighScore()
    {
        highScoreText.text = highScore.ToString();
    }
}
