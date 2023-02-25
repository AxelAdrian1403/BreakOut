using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public Transform transformPuntajeAlto;
    public Transform transformPuntajeActual;
    public TMP_Text textoPuntajeAlto;
    public TMP_Text textoActual;
    public PuntajeAlto puntajeAltoSO;
    //public int puntos = 0;
    //public int puntajeAlto = 10000;

    // Start is called before the first frame update
    void Start()
    {
        transformPuntajeActual = GameObject.Find("PuntajeActual").transform;
        transformPuntajeAlto = GameObject.Find("PuntajeAlto").transform;

        textoActual = transformPuntajeActual.GetComponent<TMP_Text>();
        textoPuntajeAlto = transformPuntajeAlto.GetComponent<TMP_Text>();

        //if(PlayerPrefs.HasKey("PuntajeAlto"))
        //{
        //    puntajeAlto = PlayerPrefs.GetInt("PuntajeAlto");
        //    textoPuntajeAlto.text = $"Puntaje Alto: {puntajeAlto}";
        //}
        puntajeAltoSO.Cargar();
        textoPuntajeAlto.text = $"Puntaje Alto: {puntajeAltoSO.puntajeAlto}";
        puntajeAltoSO.puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textoActual.text = $"Puntaje Actual: {puntajeAltoSO.puntaje}";

        if(puntajeAltoSO.puntaje > puntajeAltoSO.puntajeAlto)
        {
            puntajeAltoSO.puntajeAlto = puntajeAltoSO.puntaje;
            textoPuntajeAlto.text = $"Puntaje Alto: {puntajeAltoSO.puntajeAlto}";
            puntajeAltoSO.Guardar();
            //PlayerPrefs.SetInt("PuntajeAlto", puntos);
        }
    }

    private void FixedUpdate()
    {
        puntajeAltoSO.puntaje += 50;
    }
}
