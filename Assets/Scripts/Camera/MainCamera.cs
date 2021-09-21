using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Dampen camera roll to be half as much as plane roll.
        float roll = transform.parent.eulerAngles.z;
        Vector3 eulers = transform.eulerAngles;
        if (roll > 180f)
            roll = 360f - roll;
        eulers.z = -roll * 0.5f;
        transform.eulerAngles = eulers;
    }
}
