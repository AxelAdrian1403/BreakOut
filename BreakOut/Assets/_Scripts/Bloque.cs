using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public int resistencia = 1;
    public UnityEvent AumentarPuntaje;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(resistencia <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void RebotarBola(Collision collision) //Permite que las clases hijo hagan un override o una sobreescritura al metodo de la clase padre
    {
        //Polimorfismo
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;

        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        resistencia--;
    }
}
