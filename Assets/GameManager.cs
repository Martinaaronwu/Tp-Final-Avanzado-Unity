using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int puntos = 0;

    void Update()
    {
        Debug.Log("Puntos: " + puntos);
    }
}