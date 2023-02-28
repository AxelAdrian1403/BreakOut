using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public abstract class ObjetoPersistente : ScriptableObject
{
    public void Guardar(string nombreArchivo = null)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(ObtenerRuta(nombreArchivo));
        var json = JsonUtility.ToJson(this);

        bf.Serialize(file, json);
        file.Close();
    }

    public virtual void Cargar(string nombreArchivo = null)
    {
        var bf = new BinaryFormatter();
        var archivo = File.Open(ObtenerRuta(nombreArchivo), FileMode.Open);
        JsonUtility.FromJsonOverwrite((string)bf.Deserialize(archivo), this);
        archivo.Close();
    }

    public string ObtenerRuta(string nombreArchivo = null)
    {
        var nombreArchivoCompleto = string.IsNullOrEmpty(nombreArchivo) ? name : nombreArchivo;
        return string.Format("{0}/{1}.pers", Application.persistentDataPath, nombreArchivoCompleto);
    }
}
