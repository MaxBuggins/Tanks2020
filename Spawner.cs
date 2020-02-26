using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;

    float countDown = 0;
    public float frequency = 1;

    void Start()
    {
        
    }

    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown < 0)
        {
            Instantiate(obj, transform.position, Quaternion.identity);
            countDown = frequency;
        }
    }
}
