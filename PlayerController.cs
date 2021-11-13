using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Referencia al Character Controller
    CharacterController controller;
    private Vector3 direction;

    //Velocidad del personaje
    float speed = 5;

    //Velocidad rotacion personaje
    float rotationSpeed = 85;

    //Para la gravedad
    public float gravity = 1;

    //Para el salto
    public float jumpForce = 2;
        
    

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float verticalSpeed = direction.y;

        //Se calcula la direccion de movimiento
        direction = transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //Movimiento Arcade
        direction += transform.right * Input.GetAxis("Transversal") * speed * Time.deltaTime;

        //Movimiento tipo MMO
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0));


        direction.y = verticalSpeed;

        //Se aplica la gravedad
        if (controller.isGrounded == false)
            direction.y -= gravity * Time.deltaTime;
        else
            //Solo se puede saltar si el personaje está en el suelo
            if (Input.GetButtonDown("Jump"))
            direction.y = jumpForce;

        //Mueve al personaje
        controller.Move(direction);
        

	}
}
