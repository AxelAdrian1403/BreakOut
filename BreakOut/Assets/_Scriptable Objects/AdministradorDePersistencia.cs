using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDePersistencia : MonoBehaviour
{
    public List<PuntajePersistente> objetosAGuardar;
    // Start is called before the first frame update

    public void OnEnable()
    {
        for(int i = 0; i < objetosAGuardar.Count; i++)
        {
            var so = objetosAGuardar[i];
            so.Cargar();
        }
    }

    public void OnDisable()
    {
        for (int i = 0; i < objetosAGuardar.Count; i++)
        {
            var so = objetosAGuardar[i];
            so.Guardar();
        }
    }
}
