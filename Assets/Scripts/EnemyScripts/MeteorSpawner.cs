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
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        // yPos needs to be outside of the viewport/screen. So I need something that greater than 1
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
