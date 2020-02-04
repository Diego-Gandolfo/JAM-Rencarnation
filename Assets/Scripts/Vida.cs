using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima; // Inicializa la vidaActual a la vidaMaxima.
    }

    public void RestarVida(float vidaPerdida) // Es llamada cuando hay que RestarVida y recibe un float con la cantidad de Vida a restar
    {
        vidaActual -= vidaPerdida; // Resta los Puntos de Vida

        if (vidaActual <= 0) // Si la vida llega a cero
        {
            Destroy(gameObject); // Destruye el Objeto
        }
    }
}