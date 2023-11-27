using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopLights : MonoBehaviour
{
    public float changeTime = 1f;
    public GameObject lightBlue;
    public GameObject lightRed;

    private float currentTime;

    private void Start()
    {
        lightBlue.SetActive(false);
        lightRed.SetActive(true);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= changeTime)
        {
            lightBlue.SetActive(!lightBlue.activeSelf);
            lightRed.SetActive(!lightRed.activeSelf);
            currentTime = 0;
        }
    }
}
