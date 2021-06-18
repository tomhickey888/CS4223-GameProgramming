using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerPrefs.GetInt("score").ToString();
    }
}
