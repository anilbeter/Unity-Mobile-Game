using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawner;
    [SerializeField] private bool hasBoss;
    public bool canSpawnBoss = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EndGameManager.endManager.gameOver)
            return;
        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            if (!hasBoss)
            {
                EndGameManager.endManager.StartResolveSequence();
            }
            else
            {
                canSpawnBoss = true;
            }
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }
            gameObject.SetActive(false);
            // create a function that will check if the player survived the last spawned enemy/meteor
            //   ---- win or lose screen
            //   ------- GAME MANAGER
        }
    }
}
