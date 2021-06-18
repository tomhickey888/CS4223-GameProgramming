using UnityEngine;

public class Initializer : MonoBehaviour
{
    public string defaultName = " ";
    public int defaultScore = 0;
    public float defaultWordSpeed = 1.5f;

    void Start()
    {
        PlayerPrefs.SetString("name", defaultName);
        PlayerPrefs.SetInt("score", defaultScore);
        PlayerPrefs.SetFloat("wordSpeed", defaultWordSpeed);
    }
}
