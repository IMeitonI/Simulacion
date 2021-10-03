using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public struct MyVector2 {
    public float y;
    public float x;


    public MyVector2(float x, float y) {
        this.y = y;
        this.x = x;
    }

    public MyVector2 suma(MyVector2 variable) {
        return this+variable ;
    }
    public static MyVector2 operator + (MyVector2 a, MyVector2 b) {
        return new MyVector2(a.x + b.x, a.y + b.y);
    }

    public MyVector2 resta(MyVector2 variable) {
        return this- variable;
    }
    public static MyVector2 operator - (MyVector2 a, MyVector2 b) {
        return new MyVector2(a.x - b.x, a.y - b.y);
    }


    public MyVector2 multiplicar(float variable) {
        
        return this *variable;
    }
    public static MyVector2 operator * (MyVector2 a ,float variable) {
        return new MyVector2(a.x * variable, a.y * variable);
    }
    public static MyVector2 operator *(MyVector2 a, int variable) {
        return new MyVector2(a.x * variable, a.y * variable);
    }

    public float sacarMagnitud() {
        return Mathf.Abs(Mathf.Sqrt(Mathf.Pow(this.x, 2) + Mathf.Pow(this.y, 2)));
    }

    public MyVector2 normalizar() {
        float magnitud =sacarMagnitud();
        if (magnitud == 0){
            return new MyVector2(0,0);
        }
        return new MyVector2(x/magnitud, y/magnitud);
    }
    public void DrawVector( Color color, float duracion=0) {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y), color, duracion);
    }
    public void DrawVector(MyVector2 origen, Color color, float duracion=0) {
        Debug.DrawLine(new Vector3(origen.x, origen.y), new Vector3(x + origen.x, y+ origen.y), color, duracion);
    }
    public MyVector2 Mylerp(MyVector2 a, MyVector2 b, float t) {
        var vector = a.suma((b.resta(a)).multiplicar(t));
        return vector ;
    }
    public MyVector2 convert(Vector3 a) {

        return new MyVector2(a.x, a.y);
    }

    public override string ToString() {
        return ("(" +x.ToString()+  ", " + y.ToString()+")" );
    }

   

}
