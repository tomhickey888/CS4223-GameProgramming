using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    private float fixedDeltaTime;

    public void Change (float value)
    {
        GetComponent<Text>().text = value.ToString() + "%";
        Time.timeScale = (value / 100.0f);
    }
}
