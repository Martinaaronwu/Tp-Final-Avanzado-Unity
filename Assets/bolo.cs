using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
    public float rayDistance = 0.2f;
    public bool yaSumo = false;

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.blue);

        if (!Physics.Raycast(ray, rayDistance) && !yaSumo)
        {
            yaSumo = true;
            GameManager.puntos++;
            Debug.Log("Bolo caído");
        }
    }
}