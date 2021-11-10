using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polares : MonoBehaviour
{
    [SerializeField] float radial, angulo;
    [Header("Velocidad y aceleracion")]
    [SerializeField] float velRad,velAng,aceRad,aceAng;
    [SerializeField] MyVector2 v2 ;
    private void Update() {
        
        velRad += aceRad *Time.deltaTime;
        velAng += aceAng*Time.deltaTime;
        radial += velRad * Time.deltaTime;
        limites();
        angulo += velAng * Time.deltaTime;
        v2 = Cartesian(radial, angulo);
        transform.position =new Vector3(v2.x,v2.y);
        v2.DrawVector(Color.green);
        Debug.Log(radial);
       
    }
    MyVector2 Cartesian(float rad, float ang) {
        float x = rad * Mathf.Cos(ang);
        float y = rad * Mathf.Sin(ang);
        return new MyVector2(x, y);
        
    }

    void limites() {
        if(radial >= 4.5f || radial <=-4.5f) {
            velRad = -velRad;
            
        }
    }
}
