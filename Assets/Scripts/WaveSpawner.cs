using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float countdown = 2f;
    public TextMeshProUGUI waveCountdownText;
    private int waveIndex = 0;
    void Update()
    {
        if (countdown <= 0f)
        {
            //SpawnWave();
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        //Instantiate(enemyPrefab, transform.position, transform.rotation);
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
