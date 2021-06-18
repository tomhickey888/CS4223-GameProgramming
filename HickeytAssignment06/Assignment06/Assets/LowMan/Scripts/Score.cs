using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject Prefab;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int score = PlayerPrefs.GetInt("score");
            score += 100;
            PlayerPrefs.SetInt("score", score);
            
            Destroy(gameObject);

            Vector3 position = new Vector3(Random.Range(-10f, 10f), 1.75f, Random.Range(-10f, 10f));
            Transform PointsSpheres = GameObject.FindGameObjectWithTag("PointsSpheres").transform;

            var sphere = Instantiate(Prefab, position, Quaternion.identity);
            sphere.transform.SetParent(PointsSpheres, true);
        }
    }
}
