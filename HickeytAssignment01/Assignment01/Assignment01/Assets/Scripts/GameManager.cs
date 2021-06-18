using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float RestartTime = 1f;
    bool gameIsOver = false;
    public GameObject completeLevelUI;


    public void CompleteLevel()
    {
        Debug.Log(SceneManager.GetActiveScene().name + " Complete");
        completeLevelUI.SetActive(true);
    }
 
    public void GameOver()
    {
        if (gameIsOver == false)
        {
            gameIsOver = true;
            Debug.Log("Game Over");
            Invoke("Restart", RestartTime);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
