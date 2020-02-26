using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public GameObject tank;
    public Camera cam;
    public bool P1_camera = true;
    //public string[] playercamera = { "p1", "p2", "p3", "p4" };

    void Start()
    {
        if (P1_camera == true)
        {
            cam.rect = new Rect(0f, 0.5f, 1f, 0.5f);
        }
        if (P1_camera == false)
        {
            cam.rect = new Rect(0f, 0f, 1f, 0.5f);
        }
    }

    void Update()
    {
    }
}
