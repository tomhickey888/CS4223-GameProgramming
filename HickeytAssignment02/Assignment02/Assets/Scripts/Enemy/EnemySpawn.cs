using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public bool shouldSpawn;
    public Enemy[] enemyPrefabs;
    public float[] moveSpeedRange;
    public int[] healthRange;

    private Bounds spawnArea;
    private GameObject player;

    public void SpawnEnemies(bool shouldSpawn)
    {
        if(shouldSpawn)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    Vector3 RandomSpawnPosition()
    {
        float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float y = 0.5f;
        float z = Random.Range(spawnArea.min.z, spawnArea.max.z);

        return new Vector3(x, y, z);
    }

    void SpawnEnemy()
    {
        if(shouldSpawn == false || player == null)
        {
            return;
        }

        int index = Random.Range(0, enemyPrefabs.Length);
        var newEnemy = Instantiate(enemyPrefabs[index], RandomSpawnPosition(), Quaternion.identity) as Enemy;
        newEnemy.Initialize(player.transform, Random.Range(moveSpeedRange[0], moveSpeedRange[1]), Random.Range(healthRange[0], healthRange[1]));
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnArea = this.GetComponent<BoxCollider>().bounds;
        SpawnEnemies(shouldSpawn);
        InvokeRepeating("SpawnEnemy", 0.5f, 1.0f);
    }
}
