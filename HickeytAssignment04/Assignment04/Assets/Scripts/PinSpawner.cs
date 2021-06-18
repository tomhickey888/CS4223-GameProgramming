using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    public static int PinCount;

    public GameObject pinPrefab;
    public float modifier;

    private void Awake()
    {
        PinCount = 0;
    }

    private void Update()
    {
        modifier = PlayerPrefs.GetFloat("pinSpeed");

        if (Input.GetButtonDown("Fire1"))
        {
            SpawnPin();
        }
    }

    private void SpawnPin()
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }

public void End()
    {
        enabled = false;
    }

    public void Restart()
    {
        enabled = true;
    }
}
