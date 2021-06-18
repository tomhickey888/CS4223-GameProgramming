using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public GameObject player;
    public int lives;
    public GameObject GameOver;
    public GameObject HeadsUp;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.GetComponent<Canvas>().enabled = false;
        HeadsUp.GetComponent<Canvas>().enabled = true;
        enemyAgent.updateRotation = false;;
        lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            if (lives > 1)
            {
                lives--;
                PlayerPrefs.SetInt("lives", lives);
                PlayerPrefs.Save();
            }
            else
            {
                GameOver.GetComponent<Canvas>().enabled = true;
                HeadsUp.GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
