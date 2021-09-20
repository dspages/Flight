using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePhysics : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float drag = 0.5f;
    // [SerializeField] float lift = 0.03f;

    private float roll = 0f;
    private float pitch = 0f;
    private float yaw = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    Vector3 GetForwardVector()
    {
        return Vector3.Normalize(transform.forward);
    }

    void SetRoll(Vector3 movement)
    {
        if (movement.y < 0f && roll < 10f)
            roll += +60f * Time.deltaTime;
        else if (movement.y > 0f && roll > -10f)
            roll += -60f * Time.deltaTime;
        else if (roll > 60f * Time.deltaTime)
            roll += -60f * Time.deltaTime;
        else if (roll < -60f * Time.deltaTime)
            roll += 60f * Time.deltaTime;
        else roll = 0f;
    }

    float FlattenPitch(Vector3 movement, Vector3 eulers)
    {
        if (movement.x == 0f)
        {
            if (eulers.x > 180f && 360f - eulers.x > 120f * Time.deltaTime)
            {
                return 30f * Time.deltaTime;
            }
            if (eulers.x < 180f && eulers.x > -120f * Time.deltaTime)
            {
                return -30f * Time.deltaTime;
            }
            // else return -eulers.x;
        }
        return 0f;
    }

    public void ApplyPerFrameControls(Vector3 movement, float engineAccelleration)
    {
        Vector3 eulers = transform.eulerAngles;
        SetRoll(movement);
        eulers.z = roll;
        eulers.y += movement.y * Time.deltaTime;
        if (eulers.x < 30f || eulers.x > 330f)
            eulers.x += movement.x * Time.deltaTime;
        Debug.Log(eulers.x);
        eulers.x += FlattenPitch(movement, eulers);
        transform.eulerAngles = eulers;
        speed += engineAccelleration * Time.deltaTime;
        speed -= speed * drag * Time.deltaTime;
        transform.position += GetForwardVector() * speed * Time.deltaTime;
    }
}
