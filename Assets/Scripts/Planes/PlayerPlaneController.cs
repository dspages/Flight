using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneController : PlaneController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Roll(-1f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Roll(+1f);
        }
        else
        {
            Roll(0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Yaw(-1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Yaw(+1f);
        }
        else
        {
            Yaw(0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Pitch(-1f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Pitch(+1f);
        }
        else
        {
            Pitch(0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Accellerate(+1f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Accellerate(-1f);
        }
        else
        {
            Accellerate(0f);
        }
        ApplyPhysics();
    }
}
