using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Genera un prefab donde el usuario hizo clic
/// </summary>
public class ClicSpawner : MonoBehaviour
{
    /// <summary>
    /// Prefab a instanciar
    /// </summary>
    public GameObject prefab;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Sólo si se hace clic en el botón izdo. de ratón
	    if(Input.GetButtonDown("Fire1"))
        {
            //Se crea un rayo cuyo origen es el cursor del ratón
            //Y la dirección es donde mire la cámara
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Aquí se guarda información acerca de la colisión del rayo
            RaycastHit hit;

            //Se lanza el rayo, y se compueba que colisiona con algo
            if(Physics.Raycast(ray, out hit))
            {
                //Sólo si colisinó con el suelo, se instancia el prefab
                if(hit.collider.tag == "Floor")
                    Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
	}
}
