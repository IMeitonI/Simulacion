using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {
    public float limitY = 4.5f, limitX = 4.5f, minX = -4.5f, minY = -4.5f;
    [SerializeField] float speedLimit = 5;
    [SerializeField] MyVector2 myPosition;
    public MyVector2 velocity, peso, friccion, fluidos;
    [SerializeField] float myMass = 2,gravedad =-9.8f,c;
    [SerializeField] MyVector2 acceleration, force, wind;
    [Range(0, 1)] [SerializeField] float boundness, u;
    [SerializeField] bool boxLimits;

    private void Start()
    {
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
        peso.y = myMass * gravedad;
      
        friccion = velocity.normalizar() * -u*3;
        acceleration = ApplyForce(force + wind + peso +friccion + fluidos , myMass) ;
        if (transform.position.y <= 0 ){
            fluidos = velocity.normalizar() * c * (Mathf.Pow(velocity.sacarMagnitud(), 2)  * -1 / 2);

        }

        velocity = velocity + acceleration * Time.deltaTime;
        myPosition = myPosition + velocity * Time.deltaTime;

        if (velocity.sacarMagnitud() > speedLimit) {
            velocity = velocity.normalizar();
            velocity = velocity.multiplicar(speedLimit);
        }

        if (myPosition.x >= limitX && boxLimits) {
            velocity.x = -velocity.x;
            myPosition.x = limitX   ;
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
            myPosition.y = limitY ;
            loseVel();
        }

        void loseVel() {
            velocity = velocity* boundness;
        }

        MyVector2 ApplyForce(MyVector2 force, float mass) {
            return force*(1/mass);
        }
    }
}
