using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawner;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }
            EndGameManager.endManager.ResolveGame();
            // create a function that will check if the player survived the last spawned enemy/meteor
            //   ---- win or lose screen
            //   ------- GAME MANAGER
        }
    }
}
