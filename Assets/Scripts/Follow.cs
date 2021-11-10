using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    MyVector2 newWorldPos;
    MyVector2 velocity, acceleration;
    [SerializeField] float speed;
    [SerializeField] bool followAcele;
    // Update is called once per frame
    void Update() {
        Followf();
        AccelerationFollow();
    }
    private MyVector2 GetWorldMousePosition() {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        return newWorldPos.convert(worldPos); ;
    }
    private void RotateZ(float radians) {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }

    void LookAt(MyVector2 worlPosition) {
        MyVector2 draw = worlPosition;
        draw = draw - draw.convert(transform.position);
        draw.normalizar();
        float angulo = Mathf.Atan2(draw.y, draw.x);

        RotateZ(angulo);
    }

     void Followf() {
        if (followAcele) return;
        MyVector2 direc = GetWorldMousePosition() - newWorldPos.convert(transform.position);
        velocity = direc * speed;
        LookAt(velocity.convert(transform.position) + velocity);
        Vector3 finalPos = new Vector3(velocity.x, velocity.y,0);
        transform.position += finalPos * Time.deltaTime;
    }
     void AccelerationFollow() {
        if (!followAcele) return;
            acceleration  = GetWorldMousePosition() - newWorldPos.convert(transform.position);
            velocity = velocity + acceleration *Time.deltaTime;
            LookAt(velocity.convert(transform.position) + velocity);
            Vector3 finalPos = new Vector3(velocity.x, velocity.y, 0);
            transform.position += finalPos * Time.deltaTime;
        
    }
}
