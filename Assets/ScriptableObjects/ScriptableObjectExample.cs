using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(menuName = "ScriptableObject/PowerUpSpawner", fileName = "Spawner")]

public class ScriptableObjectExample : ScriptableObject
{
    public int spawnThreshold;
    public GameObject[] powerUp;

    public void SpawnPowerUp(Vector3 spawnPos)
    {
        int randomChance = Random.Range(0, 100);
        if (randomChance > spawnThreshold)
        {
            int randomPowerUp = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[randomPowerUp], spawnPos, Quaternion.identity);
        }
    }
}
