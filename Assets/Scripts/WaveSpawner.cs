using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float countdown = 2f;
    public TextMeshProUGUI waveCountdownText;
    private int waveIndex = 0;
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return; // Don't spawn new enemies if there are still alive enemies
        }
        if (countdown <= 0f)
        {
            //SpawnWave();
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return; // Exit the Update method to prevent spawning multiple waves at once
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count; // Reset the count of alive enemies for the new wave

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            this.enabled = false; // Disable the spawner if all waves are completed
        }
    }
    void SpawnEnemy(GameObject enemy)
    {
        //Instantiate(enemyPrefab, transform.position, transform.rotation);
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
       
    }
}
