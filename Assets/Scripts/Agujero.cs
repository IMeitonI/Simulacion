using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agujero : MonoBehaviour
{
    public float limitY = 4.5f, limitX = 4.5f, minX = -4.5f, minY = -4.5f;
    [SerializeField] float speedLimit = 5;
    [SerializeField] MyVector2 myPosition;
    public MyVector2 velocity, peso, friccion,direccion, fGravitacional;
    [SerializeField] float myMass = 2, gravedad = -9.8f, c, otherMass=10,variable;
    [SerializeField] MyVector2 acceleration, force, wind;
    [Range(0, 1)] [SerializeField] float boundness, u;
    [SerializeField] Transform otherObj;
    [SerializeField] bool boxLimits;

    private void Start() {
        myPosition = myPosition.convert(transform.position);
    }

    private void Update() {
        transform.position = new Vector3(myPosition.x, myPosition.y);
        myPosition.DrawVector(Color.red);
        acceleration.DrawVector(myPosition, Color.blue);
        velocity.DrawVector(myPosition, Color.green);
        UpdatePosition();
    }
    public void UpdatePosition() {
        myPosition = new MyVector2(transform.position.x, transform.position.y);
        //sumatoria de fuerzas
        //peso.y = myMass * gravedad;
        direccion = direccion.convert(otherObj.position) - direccion.convert(transform.position);
        float r = direccion.sacarMagnitud();
        variable = (otherMass * myMass); // (Mathf.Pow(r, 2));
        direccion = direccion.normalizar();
        if (r > 1) fGravitacional = direccion * variable;
        else acceleration = new MyVector2(0, 0);
        //friccion = velocity.normalizar() * -u * 3;
        acceleration = ApplyForce(fGravitacional+ force, myMass);
        fGravitacional.DrawVector(myPosition, Color.black);
        velocity = velocity + acceleration * Time.deltaTime;
        myPosition = myPosition + velocity * Time.deltaTime;
      

        if (velocity.sacarMagnitud() > speedLimit) {
            velocity = velocity.normalizar();
            velocity = velocity.multiplicar(speedLimit);
        }

        if (myPosition.x >= limitX && boxLimits) {
            velocity.x = -velocity.x;
            myPosition.x = limitX;
            loseVel();
        } else if (myPosition.x <= minX && boxLimits) {
            velocity.x = -velocity.x;
            myPosition.x = minX;
            loseVel();
        }
        if (myPosition.y <= minY && boxLimits) {
            velocity.y = -velocity.y;
            myPosition.y = minY;
            loseVel();

        } else if (myPosition.y >= limitY && boxLimits) {
            velocity.y = -velocity.y;
            myPosition.y = limitY;
            loseVel();
        }

        void loseVel() {
            velocity = velocity * boundness;
        }

        MyVector2 ApplyForce(MyVector2 force, float mass) {
            return force * (1 / mass);
        }



    }

   
    

    
}
