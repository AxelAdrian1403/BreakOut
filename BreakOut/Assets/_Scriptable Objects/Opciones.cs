using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Opciones", menuName = "Herramientas/Opciones", order = 1)]
public class Opciones : ObjetoPersistente
{
    public float velocidadBola = 30;
    public dificultad nivelDificultad = dificultad.facil;
    

    public enum dificultad
    {
        facil,
        normal,
        dificil
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadBola = (int)nuevaVelocidad;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        nivelDificultad = (dificultad)nuevaDificultad;
    }
}
