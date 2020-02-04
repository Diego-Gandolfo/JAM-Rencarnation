using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public bool jugador = false;

    public float velocidadMovimiento;
    public float velocidadRotacion;

    public float distanciaMinimaAtaque;
    public float distanciaMaximaAtaque;

    public float limiteHorizontal;
    public float limiteVertical;

    public Transform transformEnemigoMasCercano;

    void Start()
    {
        if (gameObject.tag == "NaveJugador") // Se fija si el objeto es una Nave controlada por el Jugador.
        {
            jugador = true;
        }

       /* if (jugador == false)
        {
            transformJugador = GameObject.FindGameObjectWithTag("NaveJugador").transform;
        }*/
    }

    void Update()
    {
        float traslacion; // Variable Local que solo sirve dentro del Update para Mover la Nave
        float rotacion; // Variable Local que solo sirve dentro del Update para Rotar la Nave

        if (gameObject.tag == "NaveJugador") // Se fija si el objeto es una Nave controlada por el Jugador.
        {
            traslacion = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime; // Guarda el Eje Vertical y lo normaliza.
            rotacion = Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime; // Guarda el Eje Horizontal y lo normaliza.

            transform.Translate(0, traslacion, 0); // Mueve la Nave del Jugador
            transform.Rotate(0, 0, -rotacion); // Rota la Nave del Jugador
        }
        else // Si no es una Nave controlada por el Jugador.
        {
            if (gameObject.tag == "NaveAzul") // Se fija si es una NaveAzul
            {
                // Hace magia para buscar al Enemigo Más Cercano
                float distanciaEnemigoMasCercano = Mathf.Infinity;
                NaveRoja enemigoMasCercano = null;
                NaveRoja[] todosLosEnemigos = GameObject.FindObjectsOfType<NaveRoja>();

                foreach (NaveRoja enemigoActual in todosLosEnemigos)
                {
                    float distanciaConEnemigo = (enemigoActual.transform.position - this.transform.position).sqrMagnitude;
                    if (distanciaConEnemigo < distanciaEnemigoMasCercano)
                    {
                        distanciaEnemigoMasCercano = distanciaConEnemigo;
                        enemigoMasCercano = enemigoActual;
                    }
                }

                transformEnemigoMasCercano = enemigoMasCercano.GetComponent<Transform>(); // Busca el Transform del Enemigo Más Cercando

                if (Vector2.Distance(transform.position, transformEnemigoMasCercano.position) > distanciaMinimaAtaque) // Si está más lejos que la distancia mínima
                {
                    // Se acerca
                    transform.position = Vector2.MoveTowards(transform.position, transformEnemigoMasCercano.position, velocidadMovimiento * Time.deltaTime);

                    // Gira hacia él
                    Vector3 diferencia = transformEnemigoMasCercano.position - transform.position;
                    float rotacionZ = Mathf.Atan2(diferencia.x, diferencia.y) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, -rotacionZ);
                }

                else if (Vector2.Distance(transform.position, transformEnemigoMasCercano.position) < distanciaMaximaAtaque) // Si está más carca que la distancia máxoma
                {
                    // Lo comento porque hace algo raro cuando está en el punto medio y no le voy a dedicar tiempo ahora a arreglarlo
                    //transform.position = Vector2.MoveTowards(transform.position, transformEnemigoMasCercano.position, -velocidadMovimiento * Time.deltaTime);

                    // Gira hacia él (aunque no sé bien por qué, sólo gira si me muevo, si estoy quieto a su espalda no hace nada "Si me quedo quieto no me ve...")
                    Vector3 diferencia = transformEnemigoMasCercano.position - transform.position;
                    float rotacionZ = Mathf.Atan2(diferencia.x, diferencia.y) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotacionZ);
                }
            }

            if (gameObject.tag == "NaveRoja")
            {
                float distanciaEnemigoMasCercano = Mathf.Infinity;
                NaveAzul enemigoMasCercano = null;
                NaveAzul[] todosLosEnemigos = GameObject.FindObjectsOfType<NaveAzul>();

                foreach (NaveAzul enemigoActual in todosLosEnemigos)
                {
                    float distanciaConEnemigo = (enemigoActual.transform.position - this.transform.position).sqrMagnitude;
                    if (distanciaConEnemigo < distanciaEnemigoMasCercano)
                    {
                        distanciaEnemigoMasCercano = distanciaConEnemigo;
                        enemigoMasCercano = enemigoActual;
                    }
                }

                transformEnemigoMasCercano = enemigoMasCercano.GetComponent<Transform>();

                if (Vector2.Distance(transform.position, transformEnemigoMasCercano.position) > distanciaMinimaAtaque)
                {
                    transform.position = Vector2.MoveTowards(transform.position, transformEnemigoMasCercano.position, velocidadMovimiento * Time.deltaTime);

                    Vector3 diferencia = transformEnemigoMasCercano.position - transform.position;
                    float rotacionZ = Mathf.Atan2(diferencia.x, diferencia.y) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, -rotacionZ);
                }

                else if (Vector2.Distance(transform.position, transformEnemigoMasCercano.position) < distanciaMinimaAtaque)
                {
                    //transform.position = Vector2.MoveTowards(transform.position, transformEnemigoMasCercano.position, -velocidadMovimiento * Time.deltaTime);

                    Vector3 diferencia = transformEnemigoMasCercano.position - transform.position;
                    float rotacionZ = Mathf.Atan2(diferencia.x, diferencia.y) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotacionZ);
                }
            }

            // Esto es lo que se supone que haría que no haga esa cosa rara al estar a la distancia media
            /*
            else if (Vector2.Distance(transform.position, transformEnemigoMasCercano.position) < distanciaMinimaAtaque && Vector2.Distance(transform.position, transformEnemigoMasCercano.position) > distanciaMaximaAtaque)
            {
                transform.position = this.transform.position;
            }
            */
        }

        if (transform.position.x > limiteHorizontal) // Se fija si supero el limiteHorizotal positivo.
        {
            transform.position = new Vector3(limiteHorizontal, transform.position.y, transform.position.z); // Lo hardcodea para que no se salga de la Vista de la Cámara.
        }
        else if (transform.position.x < -limiteHorizontal) // Se fija si supero el limiteHorizotal negativo.
        {
            transform.position = new Vector3(-limiteHorizontal, transform.position.y, transform.position.z); // Lo hardcodea para que no se salga de la Vista de la Cámara.
        }

        if (transform.position.y > limiteVertical) // Se fija si supero el limiteVertical positivo.
        {
            transform.position = new Vector3(transform.position.x, limiteVertical, transform.position.z); // Lo hardcodea para que no se salga de la Vista de la Cámara.
        }
        else if (transform.position.y < -limiteVertical) // Se fija si supero el limiteVertical negativo.
        {
            transform.position = new Vector3(transform.position.x, -limiteVertical, transform.position.z); // Lo hardcodea para que no se salga de la Vista de la Cámara.
        }
    }
}
