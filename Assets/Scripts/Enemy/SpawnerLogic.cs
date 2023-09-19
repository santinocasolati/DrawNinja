using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnSeconds;
    public int spawnAmount;
    public float verticalOffset;

    private bool inRange;
    private float currentTime;
    private int spawned = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            inRange = false;
        }
    }

    private void Start()
    {
        currentTime = spawnSeconds;
        transform.GetChild(0).localScale = new Vector3(GetComponent<BoxCollider2D>().size.x, 1, 1);
    }

    private void Spawn()
    {
        Vector3 spawnPos = new Vector3(Camera.main.transform.position.x + 14, verticalOffset, 0);
        Instantiate(spawnPrefab, spawnPos, Quaternion.identity);

        currentTime = 0f;
        spawned++;
    }

    private void Update()
    {
        if (inRange && spawned < spawnAmount)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= spawnSeconds)
            {
                Spawn();
            }
        }
    }
}
