using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ola : MonoBehaviour
{
   
    [SerializeField] int bolitasCantidad;
    [SerializeField] GameObject prefab;
    [Range(0,5)][SerializeField] float amplitud;
    List<GameObject> bolitas = new List<GameObject>();
    GameObject circulo;
    float x, y;

    void Start()
    {
        for (int i = 0; i < bolitasCantidad; i++) {
            circulo = Instantiate(prefab, transform);
            bolitas.Add(circulo);

        }
    }
    private void Update() {
        for (int i = 0; i < bolitasCantidad; i++) {
            circulo = bolitas[i];
            x = 4.48f - (0.5f * i);
            y = amplitud * Mathf.Sin(i + Time.time);
            circulo.transform.position = new Vector3(x, y);
        }
       
    }
}
