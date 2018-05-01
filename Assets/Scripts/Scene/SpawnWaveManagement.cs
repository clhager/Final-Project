using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWaveManagement : MonoBehaviour {
    public GameObject[] Path1;
    public GameObject[] Path2;
    private GameObject[][] Paths;
    public Wave[] Waves;
    public int currentWave = 0;
    public int timeBetweenWaves= 5;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    public Text waveCounter;
    // Use this for initialization
    void Start() {
        lastSpawnTime = Time.time;
        Paths = new GameObject[2][];
        Paths[0] = Path1;
        Paths[1] = Path2;
        waveCounter.text = "Wave left: " + Waves.Length.ToString();
}

    // Update is called once per frame
    void Update() {
        waveCounter.text = "Wave left: " + (Waves.Length - currentWave).ToString();
        if (currentWave < Waves.Length)
        {
            // 2
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = Waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < Waves[currentWave].maxEnemies)
            {
                // 3  
                lastSpawnTime = Time.time;
                int which = Random.Range(0, 2);
                GameObject newEnemy = (GameObject)
                    Instantiate(Waves[currentWave].Enemy);
                newEnemy.GetComponent<EnemyMovement>().Waypoints = Paths[which];
                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == Waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                currentWave++;
                //gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
            // 5 
        }
    }

   
        

}
[System.Serializable]
public class Wave
{
    public GameObject Enemy;
    public float spawnInterval;
    public int maxEnemies;
}
