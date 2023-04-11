using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public List<GameObject> enemyPrefabs;
    public List<Transform> enemySpawnLocations;

    public GameObject player;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            spawnEnemy();
        }
    }

    void spawnEnemy() {
        int enemyIndex = Random.Range(0, enemyPrefabs.Count);
        int spawnIndex = Random.Range(0, enemySpawnLocations.Count);
        GameObject go = Instantiate(enemyPrefabs[enemyIndex], enemySpawnLocations[spawnIndex].position, Quaternion.identity);
        go.GetComponent<MelleAttacker>().player = player;
        // Debug.Log(gameObject.transform.position);
    }
}
