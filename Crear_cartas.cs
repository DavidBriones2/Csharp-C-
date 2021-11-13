using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crear_cartas : MonoBehaviour
{
    public GameObject CartaPrefab;
    public int Ancho;
    public int Alto;

    public Transform CartasParent;

    private List<GameObject> cartas = new List<GameObject>();

    
    public Material[] materiales;
    public Texture2D[] texturas;

    Vector3 initialPosition =  Vector3.zero;


	// Use this for initialization
	void Start ()
    {
        Crear();
	}
	
	public void Crear()
    {
        int cont = 0;
        for (int i = 0; i < Ancho; i++)
        {
            for(int x = 0; x < Alto; x++)
            {
                GameObject cartaTemp = Instantiate(CartaPrefab, initialPosition + (Vector3.right * 1 * i) + (Vector3.up * 1 * x), Quaternion.Euler(new Vector3(0,180,0)));

                cartas.Add(cartaTemp);

                cartaTemp.GetComponent<Carta>().posicionOriginal = new Vector3(x, 0, i);
                cartaTemp.GetComponent<Carta> ().idCarta= cont;

                cartaTemp.transform.parent = CartasParent;
                
                cont++;
            }
        }

        AsignarTexturas();
        
    }

    void AsignarTexturas()
    {
        for (int i=0;i<cartas.Count; i++)
        {
            cartas[i].GetComponent<Carta>().PonerColor(texturas[(i)/ 2]);
        }
        
    }

    void Aleatoriedad()
    {
        List<GameObject> cartasTemp = cartas;
        int aleatorio;

        for(int i=0; i< cartas.Count; i++)
        {
            aleatorio = Random.Range(i, cartasTemp.Count);

            cartas[i].transform.position = cartas[aleatorio].transform.position;
            cartas[aleatorio].transform.position = cartas [i].GetComponent<Carta>().posicionOriginal;
            cartas [i].GetComponent<Carta>().posicionOriginal = cartas[i].transform.position;

            cartas [aleatorio].GetComponent<Carta>().posicionOriginal = cartas[aleatorio].transform.position;
        }
    }

}
