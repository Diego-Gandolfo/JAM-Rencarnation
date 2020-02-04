using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject prefabProyectil;

    public float frecuenciaEntreDisparo; // Se personaliza el tiempo que pasa entre disparos.

    private float tiempoDesdeDisparo; // Se fija cuanto paso entre disparos.

    void Start()
    {
        tiempoDesdeDisparo = frecuenciaEntreDisparo; // Inicializa el tiempo de Disparo (es una cuenta regresiva, por eso no se inicializa en 0).
    }
    void FixedUpdate()
    {
        if (gameObject.tag == "NaveJugador" && Input.GetKeyDown(KeyCode.Space) && tiempoDesdeDisparo <= 0) // Si el tiempo llega a 0 y es la Nave que maneja el Jugador y este toco la BARRA ESPACIADORA, es momento de hacer un Spawn.
        {
            Instantiate(prefabProyectil, transform.position, transform.rotation); // Instancea el prefab.
            tiempoDesdeDisparo = frecuenciaEntreDisparo; // Reinicia el tiempo de Spawn.
        }
        else if (gameObject.tag != "NaveJugador" && tiempoDesdeDisparo <= 0) // Si el tiempo llega a 0 y no es la Nave que maneja el Jugador, es momento de hacer un Spawn.
        {
            Instantiate(prefabProyectil, transform.position, transform.rotation); // Instancea el prefab.
            tiempoDesdeDisparo = frecuenciaEntreDisparo; // Reinicia el tiempo de Spawn.
        }
        else
        {
            tiempoDesdeDisparo -= Time.deltaTime; // Contador de tiempo, descontando deltaTime cada frame.
        }
    }
}
