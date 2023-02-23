using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //Permite que aparezca en el editor de Unity
    [SerializeField] public int limiteX = 23;

    //Velocidad de movimiento
    [SerializeField] public float velocidadPaddle = 5.0f;

    Transform transform;

    Vector3 mousePos2D;
    Vector3 mousePos3D;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoControl();
    }

    public void MovimientoMouse()
    {
        //Aqui se hace cualquier operacion del Input Manager
        mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z; //Integrar por medio de la posicion de la camara en Z, multiplicado por -1

        //Si pasamos las posiciones como las tenemos arriba, podriamos tener el tema de que en Unity una unidad de medida podria ser el
        //equivalente a un metro y por ende, el objeto ni siquiera apareceria en camara, por lo que hay que hacer la conversion que hicimos en el sistema
        //de pixeles, a lo que es el mundo 3D para que pueda ser vista

        mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Hacer el movimiento
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;

        //Evitar que se salga de los limites de la pantalla
        if (transform.position.x < -limiteX)
        {
            pos.x = -limiteX;
        }
        else if (pos.x > limiteX)
        {
            pos.x = limiteX;
        }

        transform.position = pos;
    }

    public void MovimientoTeclado()
    {
        //Detectando entrada de teclado, hay que cambiar la velocidad de movimiento para decir que nos moveremos hacia un lado o hacia el otro
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Movemos el transform en base a tres cosas, un vector up/down (ya que rotamos el cilindro), una velocidad de movimiento, y Time deltaTime
            //Tenemos un vector que apunta a -1, lo multiplicamos por la velocidad y agregamos el Time.deltaTime
            //Time.deltaTime es el tiempo que tarda una actualizacion de un frame
            transform.Translate(Vector2.down * velocidadPaddle * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.up * velocidadPaddle * Time.deltaTime);
        }

        Vector3 pos = this.transform.position;
        //Evitar que se salga de los limites de la pantalla
        if (transform.position.x < -limiteX)
        {
            pos.x = -limiteX;
        }
        else if (pos.x > limiteX)
        {
            pos.x = limiteX;
        }

        transform.position = pos;
    }

    public void MovimientoControl()
    {
        //Multiplicamos lo que nos de el eje de cualquier control por el vector de arriba, velocidad y deltaTime(diferencia de tiempo que hay entre frame)
        //Le debemos dar down porque si le damos el up, se moveria en sentido contrario a donde se mueva la palanca
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * velocidadPaddle * Time.deltaTime);

        Vector3 pos = this.transform.position;
        //Evitar que se salga de los limites de la pantalla
        if (transform.position.x < -limiteX)
        {
            pos.x = -limiteX;
        }
        else if (pos.x > limiteX)
        {
            pos.x = limiteX;
        }

        transform.position = pos;
    }
}
