using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text Result;
    public Text Welcome;
    public Text Choose;
    string PlayerName;

    public void OnButton()
    {
        PlayerName = Result.text;

        Welcome.text = "Welcome, " + PlayerName + "!";
        Choose.text = "Please choose your difficulty level:";
    }

    public void Easy()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Medium()
    {
        SceneManager.LoadScene("Level02");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Level03");
    }
}
