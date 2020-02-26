using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVision : MonoBehaviour
{
    public EnemyTankMovement movement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           movement.m_Follow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            movement.m_Follow = false;
        }
    }

}
