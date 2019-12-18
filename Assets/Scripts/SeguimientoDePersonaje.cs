using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoDePersonaje : MonoBehaviour {


    public GameObject objPrincipal; // Objeto a seguir (Personaje)

    public float distancia = 15; // Distancia al objetivo a seguir en el eje Z.
    public float altura = 5; // Distancia en altura desde la camara hacia el objetivo.

    public float margenAltura = 3;
    public float margenRotacion = 3;

	void Update () {
		
        if(objPrincipal.transform)
        {
            Transform objetivo = objPrincipal.transform;

            //Calculamos la rotacion actual del objetivo
            float objetivoAngulo = objetivo.eulerAngles.y;
            float objetivoAltura = objetivo.position.y + altura;

            float camaraAnguloActual = transform.eulerAngles.y;
            float camaraAlturaActual = transform.position.y;

            // Lerp = interpolacion lineal entre 2 valores
            // LerpAngle = es para que se interpole bien si hay 360º
            camaraAnguloActual = Mathf.LerpAngle(camaraAnguloActual, objetivoAngulo, margenRotacion * Time.deltaTime);
            camaraAlturaActual = Mathf.LerpAngle(camaraAlturaActual, objetivoAltura, margenAltura * Time.deltaTime);

            //Convertir el angulo en rotacion
            Quaternion rotac = Quaternion.Euler(0, camaraAnguloActual, 0);


            //Establecer la nueva posicion de la camara
            Vector3 pos = objetivo.position;
            pos -= rotac * Vector3.forward * distancia;
            pos.y = camaraAlturaActual;
            transform.position = pos;

            //Hacemos que la camara mire al objetivo
            transform.LookAt(objetivo);

        }


    }
}
