using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLookAt : MonoBehaviour
{
    
     // Update is called once per frame
    void Update()
    {
        LookAt(GetWorldMousePosition());
    }
    private MyVector2 GetWorldMousePosition() {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        

        return MyVector2.FromUnityVector(worldPos); ;
    }
    private void RotateZ(float radians) {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }

     void LookAt(MyVector2 worlPosition) {
        MyVector2 draw = worlPosition;
        draw = draw - MyVector2.FromUnityVector(transform.position);
       
        float angulo = Mathf.Atan2(draw.y, draw.x);
       
        RotateZ(angulo);
    }
}
