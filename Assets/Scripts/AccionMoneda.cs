using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionMoneda : MonoBehaviour {

    public float velocidadGiro;

    public GameObject cuentaMonedas;

	void Update () {


        // Estamos girando la moneda todo el rato en eje Y.
        // Multiplico el giro por Time.deltaTime para que la rotacion valla al mismo ritmo que la velocidad del juego, y no valla mas rapido.
        transform.Rotate(velocidadGiro * Vector3.up * Time.deltaTime);

	}

    // Cuando el jugador colisiona con la moneda ejecutamos esto.
    private void OnTriggerEnter(Collider other)
    {

        //Esto es para comprobar que la colision la hemos hecho con el jugador y no con otro objeto.
        if (other.gameObject.CompareTag("Player"))
        {

            //reproducimos el efecto de sonido
            AudioSource sonido = transform.GetComponent<AudioSource>();
            sonido.Play();
            //sumamos uno al marcador total de monedas

            cuentaMonedas.GetComponent<CuentaMonedas>().aumentarPuntuacion();

            //destruimos la moneda, pero haciendo que espere a que termine de sonar el efecto de sonido.
            Destroy(transform.gameObject, sonido.clip.length);

            //Para que no se vea el objeto mientras termina de ejecutarse el sonido
            transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
