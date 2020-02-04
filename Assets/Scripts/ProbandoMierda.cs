using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbandoMierda : MonoBehaviour
{
    public Transform transformJugador;
    public float velocidadMovimiento;
    public float distanciaAtaque;

    void Start()
    {
        transformJugador = GameObject.FindGameObjectWithTag("NaveJugador").transform;
    }
    
    void Update()
    {

        if (Vector2.Distance(transform.position, transformJugador.position) > distanciaAtaque)
        {
            //Debug.Log(transform.positon);
            //transform.positon = Vector2.MoveTowards(transform.positon, transformJugador.position, velocidadMovimiento * Time.deltaTime);
        }
    }
}
