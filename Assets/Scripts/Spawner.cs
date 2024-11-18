using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] public int Cost = 0;

    // Update is called once per frame
    public void Update()
    {
        //Se o tempo atual for maior que o tempo de spawn
        if (Time.timeSinceLevelLoad >= spawnRate)
        {
            //Spawna um inimigo
            SpawnEnemy();
            //Atualiza o tempo de spawn
            spawnRate = Time.timeSinceLevelLoad + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        //Random index
        int index = UnityEngine.Random.Range(0, enemies.Count);
        //Instancia um inimigo aleatório
        Instantiate(enemies[index], transform.position, Quaternion.identity);
    }


}
