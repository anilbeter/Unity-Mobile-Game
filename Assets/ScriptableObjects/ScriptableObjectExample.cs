using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/PowerUpSpawner", fileName = "Spawner")]

public class ScriptableObjectExample : ScriptableObject
{
    public GameObject[] powerUp;

    public void SpawnPowerUp(Vector3 spawnPos)
    {
        int randomPowerUp = Random.Range(0, powerUp.Length);
        Instantiate(powerUp[randomPowerUp], spawnPos, Quaternion.identity);
    }
}
