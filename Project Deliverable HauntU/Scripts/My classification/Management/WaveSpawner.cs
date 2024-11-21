using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner Instance;

    [Header("Wave Realated")]
    [SerializeField] public float spawnRate = 1.0f;
    [SerializeField] public float timeBetweenWaves = 3.0f;
    [SerializeField] public int enemyCount;
    [SerializeField] public int waveCount = 1;

    [Header("Boss Realated")]
    [SerializeField] public int bossWaveCount = 0;
    [SerializeField] public int bossWave = 8;

    [Header("Coordinates Boundaries")]
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;


    private bool waveIsDone = true;
    private Text waveText;

    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> boss;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        waveText = GameObject.Find("Counter").GetComponent<Text>();
    }

    private void Update()
    {
        waveText.text = "WAVE : " + waveCount.ToString();

        if (waveIsDone == true)
        {
            if(waveCount <= 10)
            {
                StartCoroutine(pocongWaveSpawner());
            }else if(waveCount <= 20)
            {
                StartCoroutine(pontiWaveSpawner());
                StartCoroutine(pocongWaveSpawner());
            }
            else if (waveCount <= 30)
            {
                StartCoroutine(toyolWaveSpawner());
                StartCoroutine(pontiWaveSpawner());
                StartCoroutine(pocongWaveSpawner());
            }


            if (waveCount == bossWave)
            {
                bossSpawner();
            }
        }
    }

    private IEnumerator pocongWaveSpawner()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 ramPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject enemyClone = Instantiate(enemies[0], ramPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }

        spawnRate -= 0.1f;
        enemyCount += 3;
        waveCount += 1;

        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }

    private IEnumerator pontiWaveSpawner()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount - 31; i++)
        {
            Vector2 ramPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject enemyClone = Instantiate(enemies[1], ramPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }

        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }

    private IEnumerator toyolWaveSpawner()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount - 60; i++)
        {
            Vector2 ramPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject enemyClone = Instantiate(enemies[2], ramPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }

        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }

    private void bossSpawner()
    {
        Vector2 ramPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject enemyClone = Instantiate(boss[bossWaveCount], ramPos, Quaternion.identity);

        bossWaveCount++;
    }

    public void ResetInstance()
    {
        spawnRate = 3.0f;
        timeBetweenWaves = 5.0f;
        enemyCount = 5;
        waveCount = 1;
        bossWaveCount = 0;
        bossWave = 8;
    }
}
