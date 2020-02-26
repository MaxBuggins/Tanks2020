using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAim : MonoBehaviour
{
    public float dist;
    public float height;

    private void Awake()
    {
    }

    private void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            height = transform.position.y - other.transform.position.y;
            dist = transform.position.x - other.transform.position.x + transform.position.z - other.transform.position.z;

            Vector3 angles = transform.eulerAngles;
            angles.x = Mathf.Atan2(dist, height);
            transform.eulerAngles = angles;
        }
    }
}

