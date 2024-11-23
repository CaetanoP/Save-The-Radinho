using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>(); // Lista de inimigos possíveis
    [SerializeField] private float initialSpawnRate = 3f; // Taxa inicial de spawn
    [SerializeField] private float spawnRateDecrease = 0.1f; // Quanto a taxa de spawn diminui com o tempo
    [SerializeField] private float minSpawnRate = 0.5f; // Taxa mínima de spawn
    [SerializeField] private int initialEnemiesPerSpawn = 1; // Número inicial de inimigos por spawn
    [SerializeField] private int maxEnemiesPerSpawn = 5; // Número máximo de inimigos por spawn
    [SerializeField] private float difficultyIncreaseRate = 10f; // Intervalo para aumentar a dificuldade (em segundos)

    private float nextSpawnTime; // Próximo momento de spawn
    private int currentEnemiesPerSpawn; // Número atual de inimigos por spawn
    private float currentSpawnRate; // Taxa atual de spawn
    private float lastDifficultyIncreaseTime; // Momento em que a dificuldade foi aumentada pela última vez

    private void Start()
    {
        currentSpawnRate = initialSpawnRate;
        currentEnemiesPerSpawn = initialEnemiesPerSpawn;
        nextSpawnTime = Time.time + currentSpawnRate;
        lastDifficultyIncreaseTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemies();
            nextSpawnTime = Time.time + currentSpawnRate;
        }

        if (Time.time >= lastDifficultyIncreaseTime + difficultyIncreaseRate)
        {
            IncreaseDifficulty();
            lastDifficultyIncreaseTime = Time.time;
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < currentEnemiesPerSpawn; i++)
        {
            int index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index], transform.position, Quaternion.identity);
        }
    }

    private void IncreaseDifficulty()
    {
        // Diminui o tempo entre os spawns
        currentSpawnRate = Mathf.Max(currentSpawnRate - spawnRateDecrease, minSpawnRate);

        // Aumenta o número de inimigos por spawn, até o máximo permitido
        if (currentEnemiesPerSpawn < maxEnemiesPerSpawn)
        {
            currentEnemiesPerSpawn++;
        }
    }
}
