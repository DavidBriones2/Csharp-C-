using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que genera un conjunto de prefabs siguiendo un patrón
/// </summary>
public class CubeGenerator : MonoBehaviour
{
    #region Variables miembro
    /// <summary>
    /// Prefab a generar
    /// </summary>
    public GameObject prefab;

    /// <summary>
    /// Número de prefabs a generar.
    /// </summary>
    public int numCubes = 10;

    /// <summary>
    /// Separación entre instancias del prefab
    /// </summary>
    public float clearance = 3;

    /// <summary>
    /// Posición del primer prefab instanciado
    /// </summary>
    Vector3 initialPosition = Vector3.zero;
    #endregion

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(PrefabGenerator());
    }

    /// <summary>
    /// Genera los prefabs (cubos) siguiendo un patrón preestablecido
    /// </summary>
    /// <returns></returns>
    IEnumerator PrefabGenerator()
    {
        #region Bucle que instancia un número de prefabs
        for (int tier = 0; tier < numCubes; tier++)
        {
            for (int fila = 0; fila < numCubes; fila++)
            {

                for (int columna = 0; columna < numCubes; columna++)
                {
                    //Se instancia
                    Instantiate<GameObject>(
                        prefab,
                        //El valor equivalente de forward es Vector3(0,0,1)
                        initialPosition +
                        (Vector3.forward * clearance * fila) +
                        //El valor equivalente de right es Vector3(1,0,0)
                        (Vector3.right * clearance * columna) +
                        //El valor equivalente de Up es Vector3(0,1,0)
                        (Vector3.up * clearance * tier),
                        Quaternion.identity);

                    yield return new WaitForSeconds(1.1f); 
                }
            }
        }
        #endregion

    }

}
