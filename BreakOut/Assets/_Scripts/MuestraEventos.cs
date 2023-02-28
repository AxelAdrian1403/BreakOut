using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MuestraEventos : MonoBehaviour
{
    public UnityEvent MiEventoUnity;
    public UnityEvent PruebaEventoUnity;
    public event EventHandler EnCasoDeEspacioPresionado;
    public event EventHandler EnCasoDeTeclaSPresionada;
    // Start is called before the first frame update
    void Start()
    {
        EnCasoDeEspacioPresionado += EventoEscuchado;
        EnCasoDeTeclaSPresionada += EventoS;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Comprobar si el evento es verdadero o falso
            EnCasoDeEspacioPresionado?.Invoke(this, EventArgs.Empty);
            MiEventoUnity.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            EnCasoDeTeclaSPresionada?.Invoke(this, EventArgs.Empty);
            PruebaEventoUnity.Invoke();
        }
    }

    public void EventoEscuchado(object sender, EventArgs e)
    {
        Debug.Log("El evento se escucho correctamente");
    }

    public void EventoS(object sender, EventArgs e)
    {
        Debug.Log("El evento lanzo una S");
    }

    public void EventoUnityDisparado()
    {
        Debug.Log("El evento Unity se disparo correctamente");
    }

    public void EventoUnityS()
    {
        Debug.Log("El evento Unity disparo una S");
    }
}
