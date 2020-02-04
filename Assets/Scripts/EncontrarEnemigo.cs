using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrarEnemigo : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		FindClosestEnemy ();
	}

	void FindClosestEnemy()
	{
        if (gameObject.tag == "NaveAzul")
        {
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
        }
	}

}
