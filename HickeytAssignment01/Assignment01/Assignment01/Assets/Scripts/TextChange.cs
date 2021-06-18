using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    public PlayerMovement player;

    public void Change (float f)
    {
        GetComponent<Text>().text = f.ToString() + "%";
        player.forwardForce = f*100;
    }
}
