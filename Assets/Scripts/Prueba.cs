using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour {
    [SerializeField] MyVector2 v2 = new MyVector2(2, 1);
    [SerializeField] MyVector2 v3 = new MyVector2(-1, 2);
    [SerializeField] MyVector2 v4, v5;
    [Range(0, 1)] [SerializeField] float t = 0.5f;


    // Update is called once per frame
    void Update()
    {
        v2.DrawVector(Color.green);
        v3.DrawVector(Color.blue);
        v4 = v3.resta(v2);
        v4.DrawVector(v2, Color.yellow);
      
    
        v5 =v5.Mylerp(v3, v2, t);
        v5.DrawVector(Color.black);





    }
}
