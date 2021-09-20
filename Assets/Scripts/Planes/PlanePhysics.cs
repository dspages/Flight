using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePhysics : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float drag = 0.5f;
    // [SerializeField] float lift = 0.03f;

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
        return Vector3.Normalize(-transform.up);
    }

    public void ApplyPerFrameControls(Vector3 movement, float engineAccelleration)
    {
        transform.Rotate(movement * Time.deltaTime);
        speed += engineAccelleration * Time.deltaTime;
        speed -= speed * drag * Time.deltaTime;
        transform.position += GetForwardVector() * speed * Time.deltaTime;
    }
}
