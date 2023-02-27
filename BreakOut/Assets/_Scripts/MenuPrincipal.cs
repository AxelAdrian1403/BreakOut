using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuOpciones;
    public GameObject menuInicial;
    
    public void IniciarJuego()
    {
        SceneManager.LoadScene(1); //Se le pasa el build index
    }

    public void FinalizarJuego()
    {
        Application.Quit(); //Funciona en el compilado
    }

    public void MostrarOpciones()
    {
        menuInicial.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void MostrarMenuInicial()
    {
        menuInicial.SetActive(true);
        menuOpciones.SetActive(false);
    }
}
