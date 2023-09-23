using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private float spriteHeight;
    private Vector3 startPosition;

    void Start()
    {
        // transform -> component on the object
        startPosition = transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }


    void Update()
    {
        transform.Translate(parallaxSpeed * Time.deltaTime * Vector3.down);

        if (transform.position.y < startPosition.y - spriteHeight)
        {
            transform.position = startPosition;
        }
    }
}
