using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilacion : MonoBehaviour
{
    [Range(0, 5)] [SerializeField] float amplitudX, amplitudY;
    [Range(0, 15)] [SerializeField] float frecuenciaX, frecuenciaY;
    

    private void Update() {
        OscilacionSeno();   
    }
    void OscilacionSeno() {
        transform.position = new Vector3(amplitudX*Mathf.Sin(frecuenciaX*Time.time), 
        amplitudY * Mathf.Sin(frecuenciaY * Time.time), 0);
    }

}
