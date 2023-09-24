using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBossFightzone : MonoBehaviour
{

    private CamMovement mainCamera;
    private float currentTime;
    [SerializeField] GameObject bossEnemyPrefab;
    [SerializeField] float timeToSpawn;

    
    private bool startCount = false;
    private bool spawned = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            startCount = true;
            cameraSet();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
        startCount = false;
        //mainCamera.GetComponent<CamMovement>().setCamMoving(true);
        }
    }

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<CamMovement>();
    }

    private void Update()
    {
        if (startCount)
        {
        currentTime += Time.deltaTime;
            if (currentTime >= timeToSpawn && !spawned)
            {
                bossSpawn();
            }
        }
    }

 

    private void cameraSet()
    {
        //Should change to an Smooth Lerp Offset.
        mainCamera.setCamMoving(false);
    }

    private void bossSpawn()
    {
        Instantiate(bossEnemyPrefab, transform.GetChild(0).position, Quaternion.identity);
        spawned = true;
        startCount = false;
    }


}
