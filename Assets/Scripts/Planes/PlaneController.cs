using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] PlanePhysics physics;
    [SerializeField] float rollPower = 200f;
    [SerializeField] float pitchPower = 200f;
    [SerializeField] float yawPower = 200f;
    [SerializeField] float minEnginePower = 5f;
    [SerializeField] float enginePower = 10f;
    [SerializeField] float maxEnginePower = 20f;
    private Vector3 turnControls = Vector3.zero;
    private float speedChangeRate = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void ApplyPhysics()
    {
        physics.ApplyPerFrameControls(turnControls, enginePower);
    }

    protected void Yaw(float rate)
    {
        turnControls.Set(turnControls.x, 360f * rate * yawPower * Time.deltaTime, turnControls.z);
    }

    protected void Pitch(float rate)
    {
        turnControls.Set(360f * rate * pitchPower * Time.deltaTime, turnControls.y, turnControls.z);
    }

    //protected void Roll (float rate)
    //{
    //    turnControls.Set(turnControls.x, turnControls.y , 360f * rate * rollPower * Time.deltaTime);
    //}

    protected void Accellerate (float rate)
    {
        if (rate == 0f)
        {
            if (enginePower > 10f + speedChangeRate * Time.deltaTime)
            {
                enginePower -= speedChangeRate * Time.deltaTime;
            }
            else if (enginePower < 10f - speedChangeRate * Time.deltaTime)
            {
                enginePower += speedChangeRate * Time.deltaTime;
            }
        }
        else
        {
            enginePower += speedChangeRate * rate * Time.deltaTime;
        }
        if (enginePower > maxEnginePower) enginePower = maxEnginePower;
        if (enginePower < minEnginePower) enginePower = minEnginePower;
    }
}
