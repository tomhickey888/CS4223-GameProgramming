using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMenu : MonoBehaviour
{
        public Text playerName;
        public Text playerNameD;
        public Dropdown dropdown;

        [SerializeField]
        private string PlayerName;

        [SerializeField]
        private int Lives;

        [SerializeField]
        private float CarSpeed;


        private void Awake()
        {
            if (PlayerPrefs.HasKey("name")) PlayerName = PlayerPrefs.GetString("name");
            else PlayerName = "Enter Name";
            playerNameD.text = PlayerName;

            dropdown.value = 0;
            PlayerPrefs.SetInt("lives", 3);
            PlayerPrefs.SetInt("livesUsed", 0);
            PlayerPrefs.SetFloat("carSpeed", 100f);
            PlayerPrefs.SetInt("score", 0);

            PlayerPrefs.Save();
        }

        public void SetSpeed(float value)
        {
            CarSpeed = value;
            PlayerPrefs.SetFloat("carSpeed", CarSpeed);
            PlayerPrefs.Save();
        }

    public void SetName()
    {
        PlayerName = playerName.text;
        PlayerPrefs.SetString("name", PlayerName);
        PlayerPrefs.Save();
    }

    public void SetLives()
    {
        switch (dropdown.value)
        {
            case 0:
                Lives = 3;
                break;
            case 1:
                Lives = 5;
                break;
            case 2:
                Lives = 7;
                break;
            case 3:
                Lives = 9;
                break;
            default:
                Lives = 3;
                break;
        }

        PlayerPrefs.SetInt("lives", Lives);
        PlayerPrefs.Save();
    }
}
