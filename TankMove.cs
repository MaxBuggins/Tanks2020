using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    public bool player1 = true;

    public float m_Speed = 12f; // How fast the tank moves forward and back
    public float m_TurnSpeed = 180f; // How fast the tank turns in degrees per second
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue; // The current value of the movement input
    private float m_TurnInputValue; // the current value of the turn input

    public float deaths = 0;

    private GameObject[] spawns;
    private GameObject spawn;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        spawns = GameObject.FindGameObjectsWithTag("Spawn");
    }

    private void OnEnable()
    {
        // when the tank is turned on, make sure it is not kinematic
        m_Rigidbody.isKinematic = false;
        // also reset the input values
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;

    }
    private void OnDisable()
    {
        // when the tank is turned off, set it to kinematic so it stops moving
        m_Rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (player1 == true)
        {
            m_MovementInputValue = Input.GetAxis("Vertical");
            m_TurnInputValue = Input.GetAxis("Horizontal");
        }

        if (player1 == false)
        {
            m_MovementInputValue = Input.GetAxis("Player 2 Vertical");
            m_TurnInputValue = Input.GetAxis("Player2 Horizontal");
        }

        if (m_Rigidbody.transform.position.y <= -10)
        {
            spawn = spawns[Random.Range(0, spawns.Length)];

            m_Rigidbody.transform.position = spawn.transform.position;

            //m_Rigidbody.transform.position = spawns.m_Rigidbody.transform.position;

            m_Rigidbody.isKinematic = true;
            m_Rigidbody.isKinematic = false;
            deaths += 1;

        }

        //if (transform.eulerAngles.z >= 20)
        //{
        //    Vector3 angles = transform.eulerAngles;
        //    angles.z = 20;
        //    transform.eulerAngles = angles;
       // }

       // if (transform.localRotation.eulerAngles.x <= -20)
       // {
       //     Vector3 angles = transform.eulerAngles;
      //      angles.z = -20;
      //      transform.eulerAngles = angles;
      //  }
    }
    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    private void Move()
    {
        // create a vector in the direction the tank is facing with a magnitude
        // based on the input, speed and time between frames
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed *
       Time.deltaTime;
        // Apply this movement to the rigidbody's position
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }
    private void Turn()
    {
        // determine the number of degrees to be turned based on the input,
        // speed and time between frames
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        // make this into a rotation in the y axis
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        // apply this rotation to the rigidbody's rotation
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
