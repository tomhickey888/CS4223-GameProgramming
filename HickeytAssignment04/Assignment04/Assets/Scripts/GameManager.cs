using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   private bool isOver = false;

    public void StartGame()
    {
        Animator anim;
        anim = FindObjectOfType<Canvas>().GetComponent<Animator>();
        anim.SetTrigger("IntroOut");
    }

    public void Quit()
    {
        if (UnityEditor.EditorApplication.isPlaying == true) UnityEditor.EditorApplication.isPlaying = false;

        else Application.Quit();
    }

    public void Restart()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().Unpause();

        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        if (isOver)
        {
            return;
        }

        else
        {
            FindObjectOfType<PinSpawner>().End();
            FindObjectOfType<Rotator>().StartStop();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("EndGame");
            isOver = true;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndActions()
    {
        if (PlayerPrefs.GetInt("lives") == 0 || PlayerPrefs.GetFloat("timer") == 0f)
        {
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timerIsRunning = false;
            FindObjectOfType<Rotator>().reverse = true;
            FindObjectOfType<Rotator>().StartStop();

            GameObject[] PinObjects = GameObject.FindGameObjectsWithTag("Pin");
            Transform[] Pins = new Transform[PinObjects.Length];

            for (int i = 0; i < PinObjects.Length; i++)
            {
                Pins[i] = PinObjects[i].transform;
            }

            StartCoroutine(FindObjectOfType<Rotator>().ShedPins(Pins, PinObjects));
        }

        else
        {
            isOver = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Reset");
            FindObjectOfType<Rotator>().StartStop();
            FindObjectOfType<PinSpawner>().Restart();
        }
    }
}
