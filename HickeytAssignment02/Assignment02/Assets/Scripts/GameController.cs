using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject PlayerObject;
    public EnemySpawn enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        var cameraRig = Camera.main.GetComponent<CameraRig>();
        cameraRig.target = PlayerObject;

        var player = GameObject.FindGameObjectWithTag("Player").GetComponent <Player>();
        player.OnPlayerDeath += OnPlayerDeath;
    }

    void OnPlayerDeath(Player player)
    {
        enemySpawn.SpawnEnemies(false);

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }

        Destroy(player.gameObject);

        Invoke("GameOver", 2f);
    }

    void GameOver()
    {
        SceneManager.LoadScene("Credits");
    }
}
