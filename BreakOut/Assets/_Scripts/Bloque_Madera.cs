using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Madera : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 3; //Definimos una resistencia diferente
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void RebotarBola()
    {
        //base.RebotarBola(); Toma las sentencias que ya hace la clase padre

    }
}
