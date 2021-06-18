using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void exit()
    {
        if (EditorApplication.isPlaying)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();

    }
}
