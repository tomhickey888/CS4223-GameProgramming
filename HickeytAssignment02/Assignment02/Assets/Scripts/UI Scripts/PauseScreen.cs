using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public Slider slider;
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public Dropdown dropdown;
    public GameObject player;
    public Material PlayerYellow;
    public Material PlayerOrange;
    public Material PlayerPurple;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused) { Resume(); }
            else { Pause(); }
        }
    }

    public void Resume()
    {
        Behaviour shootScript = (Behaviour)GameObject.FindWithTag("Player").GetComponent("PlayerShooting");
        PauseMenuUI.SetActive(false);
        shootScript.enabled = true;
        Time.timeScale = (slider.value / 100);
        GameIsPaused = false;
    }

    public void Pause()
    {
        Behaviour shootScript = (Behaviour)GameObject.FindWithTag("Player").GetComponent("PlayerShooting");
        PauseMenuUI.SetActive(true);
        shootScript.enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void exitButton()
    {
        SceneManager.LoadScene(2);
    }

    public void ColorSwitch()
    {
        switch (dropdown.value)
        {
            case 0:
                player.GetComponent<Renderer>().sharedMaterial = PlayerYellow;
                break;
            case 1:
                player.GetComponent<Renderer>().sharedMaterial = PlayerOrange;
                break;
            case 2:
                player.GetComponent<Renderer>().sharedMaterial = PlayerPurple;
                break;
        }
    }
}
