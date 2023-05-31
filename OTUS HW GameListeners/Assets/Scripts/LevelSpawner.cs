using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour, IGameUpdateListener
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float timeToSpawn = 3;
    [SerializeField] private float distanceForSpawn = 3;
    [SerializeField] private Transform playerBody;

    private float localTimer;

    public void OnGameFixedUpdate()
    {

    }

    public void OnGameUpdate()
    {
        if (localTimer >= timeToSpawn)
        {
            localTimer = 0;
            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
            Vector3 spawnPoint = playerBody.position + new Vector3(Random.Range(0, 3), 0, distanceForSpawn);
            GameObject newObstacle = Instantiate(randomObstacle, spawnPoint, Quaternion.identity);
        }
        else
        {
            localTimer += Time.deltaTime;
        }
    }
}
