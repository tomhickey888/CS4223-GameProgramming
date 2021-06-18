using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void stopGame()
    {
        SceneManager.LoadScene(2);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying == true) UnityEditor.EditorApplication.isPlaying = false;

        else Application.Quit();
    }
}
