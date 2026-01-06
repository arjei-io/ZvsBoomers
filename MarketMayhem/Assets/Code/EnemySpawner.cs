using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private GameObject[] enemyPrefabbers;

    //[SerializeField] Enemy enemy;

    [SerializeField] private float spawnRate = 2f;

    [SerializeField] private int spawnCount;

    private bool waveDone = true;

    private void Start()
    {
        //enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (waveDone == true)
        {
            StartCoroutine(Timer());
            StartCoroutine(WaveSpawner());
        }
        
    }

    private IEnumerator WaveSpawner()
    {
        waveDone = false;
        for (int i = 0; i < spawnCount; i++)
        {
            int randomSpawnPoint = Random.Range(0, spawnpoints.Length);
            Instantiate(enemyPrefabbers[0], spawnpoints[randomSpawnPoint].position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }

        spawnCount = +2;
        
        //spawnRate =- 0.5f;

        waveDone = true;
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(5);
    }
}
