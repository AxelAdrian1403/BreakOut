using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bloque_Madera : Bloque
{
    public Opciones opciones;
    public TMP_Dropdown drop;
    // Start is called before the first frame update
    void Start()
    {
        if (opciones.nivelDificultad == Opciones.dificultad.facil)
        {
            resistencia = 1;
        }
        if (opciones.nivelDificultad == Opciones.dificultad.normal)
        {
            resistencia = 2;
        }
        if (opciones.nivelDificultad == Opciones.dificultad.dificil)
        {
            resistencia = 3;
        } //Definimos una resistencia diferente
        puntosBloque = 2000;
        bloqueValor = 2;
    }

    // Update is called once per frame
    void Update()
    {
        drop.onValueChanged.AddListener(delegate { CambiosResistencia(); });
        
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision); //Toma las sentencias que ya hace la clase padre
        
    }

    public void CambiosResistencia()
    {
        if (opciones.nivelDificultad == Opciones.dificultad.facil)
        {
            resistencia = 1;
        }
        if (opciones.nivelDificultad == Opciones.dificultad.normal)
        {
            resistencia = 2;
        }
        if (opciones.nivelDificultad == Opciones.dificultad.dificil)
        {
            resistencia = 3;
        }
    }
}
