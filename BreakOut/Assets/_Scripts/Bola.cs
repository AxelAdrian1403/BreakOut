using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    public bool isGameStarted = false;
    [SerializeField]public float velocidadBola = 30.0f;
    Vector3 ultimaPosicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    Rigidbody rigidbody;
    private ControlBordes control;
    public UnityEvent BolaDestruida;

    private void Awake()
    {
        control = GetComponent<ControlBordes>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Encontrar la posicion del Paddle
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        //Seguir la posicion del paddle hasta ser disparada
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);

        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(control.salioAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
            control.salioAbajo = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioArriba = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioDerecha = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioIzquierda = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Submit") || Input.GetButton("Option"))
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
    private void FixedUpdate()
    {
        ultimaPosicion = transform.position;
    }

    private void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }
}
