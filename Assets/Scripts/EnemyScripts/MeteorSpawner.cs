using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    // this array will contains all meteor prefabs
    [SerializeField] private GameObject[] meteor;
    [SerializeField] private float spawnTime;
    private float timer;
    private int i;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
