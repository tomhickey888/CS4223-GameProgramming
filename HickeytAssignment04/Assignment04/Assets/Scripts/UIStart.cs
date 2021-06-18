using UnityEngine;

public class UIStart : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerSettings>().DisplayName();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerSettings>().DisplayLives();
    }

    public void Restart()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerSettings>().DisplayName();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerSettings>().DisplayLives();
    }
}
