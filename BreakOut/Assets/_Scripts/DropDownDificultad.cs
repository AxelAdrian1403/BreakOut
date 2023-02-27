using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownDificultad : MonoBehaviour
{
    public Opciones opciones;
    private TMP_Dropdown dificultad;
    // Start is called before the first frame update
    void Start()
    {   
        dificultad = GetComponent<TMP_Dropdown>();
        dificultad.value = (int)opciones.nivelDificultad;
        dificultad.onValueChanged.AddListener(delegate { opciones.CambiarDificultad(dificultad.value); });
    }

}
