using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MuestraSuscriptor : MonoBehaviour
{
    MuestraEventos suscriptor;
    // Start is called before the first frame update
    void Start()
    {
        suscriptor = GetComponent<MuestraEventos>();
        suscriptor.EnCasoDeEspacioPresionado += MensajeEscuchadoPorElSuscriptor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MensajeEscuchadoPorElSuscriptor(object sender, EventArgs e)
    {
        Debug.Log("El evento ha sido escuchado desde otra clase");
        suscriptor.EnCasoDeEspacioPresionado -= MensajeEscuchadoPorElSuscriptor; //Dejamos de estar suscritos
    }
}
