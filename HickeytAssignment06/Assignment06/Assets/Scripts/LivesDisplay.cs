using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("lives", 5);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerPrefs.GetInt("lives").ToString();
    }
}
