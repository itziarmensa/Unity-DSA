using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawnerJuego1 : MonoBehaviour
{
    public GameObject BolaFuego;
    public float spawnInterval = 1.0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;



    void Start()
    {

        Camera camera = Camera.main;
        float cameraHalfWidth = camera.orthographicSize * camera.aspect;
        float cameraHalfHeight = camera.orthographicSize;

        minX = camera.transform.position.x - cameraHalfWidth;
        maxX = camera.transform.position.x + cameraHalfWidth;
        minY = camera.transform.position.y - cameraHalfHeight;
        maxY = camera.transform.position.y + cameraHalfHeight;

        InvokeRepeating("SpawnFireball", 0, spawnInterval);

    }

    void SpawnFireball()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(x, y, 0);

        Instantiate(BolaFuego, spawnPosition, Quaternion.identity);
    }
}
