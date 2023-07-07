using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> zombiePrefab;
    public List<GameObject> gunPrefabs;
    public List<GameObject> guns;

    private int spawnedZombies;

    public GameObject player;
    public GameObject playerClone;
    

    private Vector3 weaponOffset = new Vector3(0, 1.5f, 1.25f);

    private Vector3 bounds_max;
    private Vector3 bounds_min;

    private int zombieCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerClone = Instantiate(player, Vector3.zero, player.transform.rotation);
        SpawnGuns();
        InvokeRepeating("SpawnZombies", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnGuns()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            guns[i] = Instantiate(gunPrefabs[i], playerClone.transform.position + weaponOffset, playerClone.transform.rotation);
            guns[i].transform.SetParent(playerClone.transform);
            guns[i].SetActive(false);
        }
    }

    void SpawnZombies()
    {
        if (spawnedZombies <= zombieCount)
        {
            int randSpawnPoint = Random.Range(0, spawnPoints.Count);
            bounds_max = spawnPoints[randSpawnPoint].GetComponent<Collider>().bounds.max;
            bounds_min = spawnPoints[randSpawnPoint].GetComponent<Collider>().bounds.min;
            float randZSpawn = Random.Range(bounds_min.z, bounds_max.z);
            int randomZombie = Random.Range(0, zombiePrefab.Count);
            Instantiate(zombiePrefab[randomZombie], new Vector3(spawnPoints[randSpawnPoint].transform.position.x, spawnPoints[randSpawnPoint].transform.position.y, randZSpawn), spawnPoints[randSpawnPoint].transform.rotation);
            spawnedZombies++;

        }
    }
}
