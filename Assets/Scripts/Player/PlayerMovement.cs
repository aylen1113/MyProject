using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //NOTA: por alguna razón a veces puede salir volando el player,a hay q ver cómo arreglarlo!!
    //Tmb el player hace fuerza contra el piso por la direccion de la camara y eso hace q se vea raro el movimiento
    //(como q está saltando o glitcheado), si alguno sabe solucionarlo agreguen nomás:P
    //cualquier cosa directamente sacamos q se pueda ver desde arriba con la cámara y la dejamos bastante fija

    [Header("Movimiento")]
    public float rapidezDesplazamiento = 10.0f;
    public float modificadorSprint; //esto igual tmb sirve si queremos q tenga sigilo, sólo q no va a correr. En vez de num positivo ponemos negativo o 0 y listo, funca!!!
    
    Vector3 direccion;
    public Transform Orientation;
    [SerializeField] Rigidbody rb;
    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //float forwardMovement = Input.GetAxis("Vertical") * speed;
        //float horizontalMovement = Input.GetAxis("Horizontal") * speed;

        //forwardMovement *= Time.deltaTime;
        //horizontalMovement *= Time.deltaTime;

        //transform.Translate(horizontalMovement, 0, forwardMovement);
    }

    private void FixedUpdate()
    {
        movimiento();
        speedControl();
    }

    void movimiento()
    {
        float speedsprint = rapidezDesplazamiento; //para poder modificar la rapidez dentro del código sin alterar la default.

        //movimiento normal.
        float movimientoAdelanteAtras = Input.GetAxis("Vertical");
        float movimientoCostados = Input.GetAxis("Horizontal");
        direccion = Orientation.forward * movimientoAdelanteAtras + Orientation.right * movimientoCostados; //obtiene informacion de la direccion mediante el transform usado


        //lógica para el sprint
        bool correr = Input.GetKey(KeyCode.LeftShift); //mientras se presione shift, bool será true.
        bool esta_corriendo = correr && movimientoAdelanteAtras > 0; // mientras correr sea true y se esté caminando en eje z, bool será true.
        if (esta_corriendo) speedsprint *= modificadorSprint; //mientras bool sera true, la velocidad será modificada.

        //desplaza el rigidbody hacia la direccion que se esté mirando con la velocidad configurada
        rb.AddForce(direccion.normalized * speedsprint * 10f, ForceMode.Force); // *10f para hacerlo un poco más rápido

    }

    //para controlar que no se pase la velocidad.
    void speedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //calcula la velocidad alcanzada

        if (flatVelocity.magnitude > rapidezDesplazamiento) //si esa velocidad se llega a pasar de la default,
        {
            Vector3 LimitedVel = flatVelocity.normalized * rapidezDesplazamiento; //calcula la max velocidad que se puede alcanzar
            rb.velocity = new Vector3(LimitedVel.x, rb.velocity.y, LimitedVel.z); //y la aplica
        }
        //if (grounded == true)
        //{
        //    rb.y = 0f;
        //}
    }

    //private void OnCollisionEnter(Collision collision) //intentando solucionar lo de la fuerza contra el piso</3
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        grounded = true;
    //    }
    //}
}
