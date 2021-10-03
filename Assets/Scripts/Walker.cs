using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    public float limitY = 4.5f, limitX = 4.5f, minX =-4.5f, minY=-4.5f;
    [SerializeField] float speedLimit = 5;
    public MyVector2 myPosition;
    public MyVector2 velocity;
    [SerializeField] MyVector2 acceleration;
    [Range (0,1)] [SerializeField] float boundness;
    [SerializeField] Transform otherObj;
    [SerializeField] bool boxLimits ;



    private void Update() {
        transform.position = new Vector3(myPosition.x, myPosition.y);
        myPosition.DrawVector(Color.red);
        acceleration.DrawVector(myPosition, Color.blue);
        velocity.DrawVector(myPosition, Color.green);
        UpdatePosition();
    }
    public void UpdatePosition() {
        myPosition = new MyVector2(transform.position.x, transform.position.y);
        acceleration = acceleration.convert(otherObj.transform.position) - acceleration.convert(transform.position);
        velocity = velocity + acceleration * Time.deltaTime;
        myPosition = myPosition + velocity *Time.deltaTime;
        if (velocity.sacarMagnitud() > speedLimit) {
            velocity = velocity.normalizar();
            velocity = velocity.multiplicar(speedLimit);
        }
      

        if (myPosition.x >= limitX && boxLimits) {
            velocity.x = -velocity.x;
            myPosition.x = limitX;
            loseVel();
        } 
        else if (myPosition.x <= minX&& boxLimits) {
            velocity.x = -velocity.x;
            myPosition.x = minX ;
            loseVel();

        }  if (myPosition.y <= minY && boxLimits) {
            velocity.y = -velocity.y;
            myPosition.y = minY;
            loseVel();

        } else if (myPosition.y >= limitY&& boxLimits) {
            velocity.y = -velocity.y;
            myPosition.y = limitY;
            loseVel();

        }

        void loseVel() {
            velocity = velocity * -boundness;
        }

      

    }
}
