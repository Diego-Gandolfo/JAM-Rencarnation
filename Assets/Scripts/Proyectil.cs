using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidadProyectil;
    public float puntosDaño;

    void Start()
    {
        velocidadProyectil *= Time.fixedDeltaTime; // Normaliza la velocidadProyectil, lo hago en el Start para que no realize esta operación tdos los frames.
    }

    void FixedUpdate()
    {
        transform.Translate(0, velocidadProyectil, 0); // Mueve el Proyectil.
    }

    void OnBecameInvisible() // Esta funcion detecta lo que se salió de la vista de la Cámara.
    {
        Destroy(gameObject); // Destruye el Objeto.
    }

    private void OnCollisionEnter2D(Collision2D objetoColisionado)
    {
        objetoColisionado.gameObject.GetComponent<Vida>().RestarVida(puntosDaño); // Llama a RestarVida del objetoColisionado y le pasa los Puntos de Daño.
        Destroy(gameObject); // Destruye el Objeto.
    }
}
