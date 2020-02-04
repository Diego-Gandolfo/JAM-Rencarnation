using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNaves : MonoBehaviour
{
    public GameObject prefabNave;

    public float frecuanciaSpawn; // Determina cuanto tiempo tiene que pasar entre Spawns.

    private float tiempoDesdeSpawn; // Lleva el tiempo que paso desde último Spawn.

    void Start()
    {
        tiempoDesdeSpawn = frecuanciaSpawn; // Inicializa el tiempo de Spawn (es una cuenta regresiva, por eso no se inicializa en 0).
    }
    void FixedUpdate()
    {
        if (tiempoDesdeSpawn <= 0) // Si el tiempo llega a 0, es momento de hacer un Spawn.
        {
            //vInstantiate(prefabNave, new Vector3(Random.Range(-2, 2) * 0.5f + transform.position.x, Random.Range(-5,5)*0.5f+transform.position.y,transform.position.z), transform.rotation); // Instancea el prefab en una posicion Aleatoria.
            Instantiate(prefabNave, transform.position, transform.rotation); // Instancea el prefab.
            tiempoDesdeSpawn = frecuanciaSpawn; // Reinicia el tiempo de Spawn.
        }
        else
        {
            tiempoDesdeSpawn -= Time.deltaTime; // Contador de tiempo, descontando deltaTime cada frame.
        }
    }
}