using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void PlayButton() { SceneManager.LoadScene("Main"); }

    public void PlayAgainButton() { SceneManager.LoadScene("Opening"); }
    
    public void CreditsButton() { SceneManager.LoadScene("Credits"); }

    public void ExitButton() { Application.Quit(); }
}
