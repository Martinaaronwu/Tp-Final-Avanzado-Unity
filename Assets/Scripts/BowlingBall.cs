using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BowlingBall : MonoBehaviour
{
    public float force = 800f;
    public float rayDistance = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Raycast hacia adelante (solo visual / lógica simple)
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * force);
        }
    }
}