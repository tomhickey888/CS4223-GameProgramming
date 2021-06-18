using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    Toggle toggle;
    public GameObject player;
    static Vector3 OSize = new Vector3();

    // Use this for initialization
    void Start()
    {
        OSize = player.gameObject.transform.localScale;

        toggle = GetComponent<Toggle>();
    }

    public void OversizeBall()
    {
        Vector3 grow = new Vector3(1.0f, 1.0f, 1.0f);

        if (player.gameObject.transform.localScale == OSize)
        {
            player.gameObject.transform.localScale += grow;
        }
        else
        {
            player.gameObject.transform.localScale = OSize;
        }
    }
}