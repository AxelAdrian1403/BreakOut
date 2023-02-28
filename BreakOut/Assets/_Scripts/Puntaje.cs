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
    public MedidorPuntaje medidorPuntaje;
    public GameObject bloquePrefab;
    private Bloque bloque;
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
        //puntajeAltoSO.Cargar();
        textoPuntajeAlto.text = $"Puntaje Alto: {medidorPuntaje.puntajeAlto}";
        medidorPuntaje.puntaje = 0;

    }

    // Update is called once per frame
    void Update()
    {
        textoActual.text = $"Puntaje Actual: {medidorPuntaje.puntaje}";

        if(medidorPuntaje.puntaje > medidorPuntaje.puntajeAlto)
        {
            medidorPuntaje.puntajeAlto = medidorPuntaje.puntaje;
            textoPuntajeAlto.text = $"Puntaje Alto: {medidorPuntaje.puntajeAlto}";
            //puntajeAltoSO.Guardar();
            //PlayerPrefs.SetInt("PuntajeAlto", puntos);
        }
    }


    public void AumentarPuntos()
    {
        var bl = bloquePrefab;
        bloque = bl.GetComponent<Bloque>();
        bloque.AumentarPuntaje.AddListener(this.AumentarPuntos);
        medidorPuntaje.puntaje += Bloque.puntosBloque;
        
    }
}
