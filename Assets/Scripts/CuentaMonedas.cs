using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuentaMonedas : MonoBehaviour {

    public int puntuacionNivel;

    public Transform monedas;
    public GameObject textoPuntuacion;
    public GameObject MenuGameOver;

    private int numMonedasNivel;

    void Start()
    {
        Time.timeScale = 1f; //El tiempo se ejecuta de manera normal de nuevo.
        //Ponemos el menu desactivado;
        MenuGameOver.SetActive(false);

        //Ponemos la puntuacion a 0 y conseguimos el numero maximo de monedas que hay en el nivel.
        puntuacionNivel = 0;
        numMonedasNivel = monedas.transform.childCount;
        //Ponemos bien la puntuacion.
        textoPuntuacion.GetComponent<Text>().text = puntuacionNivel + "/" + numMonedasNivel;
    }

    void Update () {
	

        if(puntuacionNivel == numMonedasNivel)
        {
            MenuGameOver.SetActive(true); // Activamos el menu de game over.
            Time.timeScale = 0f; //Pausamos el tiempo del juego.
        }


	}

    public void aumentarPuntuacion()
    {
        puntuacionNivel++;
        textoPuntuacion.GetComponent<Text>().text = puntuacionNivel + "/" + numMonedasNivel;
    }
}
