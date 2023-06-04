using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnBalonStart : MonoBehaviour
{
    public GameObject[] balon;
    public GameObject[] spawnPoints;

    private void Start() {
        StartCoroutine(BalonSpawnCoroutine());
    }

    private IEnumerator BalonSpawnCoroutine(){
        int randomBalon = Random.Range(0, balon.Length);
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(balon[randomBalon], spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
        Debug.Log("Balon spawned"); 
        yield return new WaitForSeconds(2f);
        StartCoroutine(BalonSpawnCoroutine());
    }
}
