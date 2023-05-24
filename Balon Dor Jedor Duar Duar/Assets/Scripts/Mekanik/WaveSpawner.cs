using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    public GameObject win;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemies;
        public int count;
        public float rate;
        
    }

    public Wave[] waves;
    private int nextWave = 0;
    public int totalEnemy = 0 ;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;
    private bool isWaveCompleted = false;
    private Transform enemyParent;

    void Start()
    {
        waveCountdown = timeBetweenWaves;

        if(spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }

        enemyParent = GameObject.FindGameObjectWithTag("Baloons").transform;
    }

    void Update()
    {
        // Debug.Log("total"+totalEnemy);
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (!isWaveCompleted && waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Target") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        // Debug.Log("Spawning Wave: " + wave.name);
        state = SpawnState.SPAWNING;

       

        for (int i = 0; i < wave.count; i++)
        {
            Transform enemy = wave.enemies[Random.Range(0, wave.enemies.Length)];
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // Debug.Log("Spawning Enemy: " + enemy.name + " at " + spawnPoint.position);
        
        Transform enemyTransform = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemyTransform.SetParent(enemyParent);

        totalEnemy++;
    }

    void WaveCompleted()
    {
        // Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {

            win.SetActive(true);
             isWaveCompleted = true;

            // Debug.Log("All Waves Complete! Looping...");
        }
        else
        {
            nextWave++;
        }
    }

   
}
