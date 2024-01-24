using System.Linq;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    float spawnDistance = 10f;

    [SerializeField]
    float spawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLaneOne", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnLaneOne()
    {
        Vector3 spawnPosition = transform.position;
        Vector3 randomishPosition = new Vector3((Random.value * -10), 0, 0);
        Quaternion playerRotation = player.transform.rotation;

        Vector3 spawnPos = spawnPosition + randomishPosition * spawnDistance;

        var newEnemy = Instantiate(enemy, spawnPos, playerRotation);

        ChangeEnemyColor(newEnemy);
    }

    void ChangeEnemyColor(GameObject enemy)
    {
        var mats = GetMaterials();

        if (Random.value % 2 == 0)
        {
            enemy.GetComponent<Renderer>().material = mats[0];
        }
        else
        {
            enemy.GetComponent<Renderer>().material = mats[1];
        }
    }

    Material[] GetMaterials()
    {
        Material[] mats = Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray();

        return mats;
    }
}
