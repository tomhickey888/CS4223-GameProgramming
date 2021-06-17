using UnityEngine;
using UnityEngine.UI;

public class IntroMenu : MonoBehaviour
{
    public Text playerName;
    public Dropdown dropdown;

    private void Awake()
    {
        string name = "";
        int lives = 3;
        int score = 0;
        int music = 0;
        float timer = 60f;

        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetFloat("timer", timer);
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("music", music);
        PlayerPrefs.Save();
    }
    public void SetName()
    {
        string name = playerName.text;
        PlayerPrefs.SetString("name", name);
        PlayerPrefs.Save();
    }

    public void SetTimer(float value)
    {
        float timer = value;
        PlayerPrefs.SetFloat("timer", timer);
        PlayerPrefs.Save();
    }

    public void SetLives()
    {
        int lives;

        switch (dropdown.value)
        {
            case 1:
                lives = 1;
                break;
            case 2:
                lives = 2;
                break;
            case 3:
                lives = 3;
                break;
            case 4:
                lives = 4;
                break;
            case 5:
                lives = 5;
                break;
            case 6:
                lives = 6;
                break;
            case 7:
                lives = 7;
                break;
            case 8:
                lives = 8;
                break;
            case 9:
                lives = 9;
                break;
            default:
                lives = 3;
                break;
        }

        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.Save();
    }
}
