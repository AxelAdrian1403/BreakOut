using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public bool isGameStarted = false;
    [SerializeField]public float velocidadBola = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Encontrar la posicion del Paddle
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        //Seguir la posicion del paddle hasta ser disparada
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetButton("Submit"))
        {
            if(!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);

                //Dispara la bola hacia arriba
                GetComponent<Rigidbody>().velocity = velocidadBola * Vector3.up;
            }
        }
    }
}
