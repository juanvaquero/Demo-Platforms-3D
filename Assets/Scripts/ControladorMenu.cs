using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour {

    public void pasarNivel1()
    {
        Time.timeScale = 1f; //El tiempo se ejecuta de manera normal de nuevo.
        SceneManager.LoadScene("Nivel1");
    }

    public void pasarNivel2()
    {
        Time.timeScale = 1f; //El tiempo se ejecuta de manera normal de nuevo.
        SceneManager.LoadScene("Nivel2");
    }


    public void salirJuego()
    {
        Application.Quit();
    }

}
