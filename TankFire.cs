using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{

    public Rigidbody m_Shell;
    // A child of the tank where the shells are spawned
    public Transform m_FireTransform;
    // The force given to the shell when firing
    public float m_LaunchForce = 30f;

    public float timer = 1;
    private float time = 0f;

    TankMove tankMove;

    private void Start()
    {
        tankMove = GetComponent<TankMove>();
    }

    private void Update()
    {
        time += Time.deltaTime;


        if (tankMove.player1 == true)
        {
            if (Input.GetButton("Fire1"))
            {
                if (time >= timer)
                {
                    Fire();
                    time = 0;
                }
            }
            if (Input.GetButton("Fire1B"))
            {
                if (time >= timer)
                {
                    Fire();
                    time = 0;
                }


            }
        }
        if (tankMove.player1 == false)
            {
                if (Input.GetButton("Fire2"))
                {
                    if (time >= timer)
                    {
                        Fire();
                        time = 0;
                    }
                }
                if (Input.GetButton("Fire2B"))
                {
                    if (time >= timer)
                    {
                        Fire();
                        time = 0;
                    }
                }
            }
        }
    

    private void Fire()
    {
        // Create an instance of the shell and store a reference to its rigidbody
        Rigidbody shellInstance = Instantiate(m_Shell,
       m_FireTransform.position,
       m_FireTransform.rotation) as Rigidbody;
        // Set the shell's velocity to the launch force in the fire
        // position's forward direction
        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }
}


