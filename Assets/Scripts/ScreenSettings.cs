using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, true, 60); // Harcodea la Resolución de Pantalla y los FPS.
    }
}