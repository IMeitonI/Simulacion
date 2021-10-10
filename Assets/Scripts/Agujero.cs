using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agujero : MonoBehaviour
{
    [Header("Physics related")]
    [SerializeField] MyVector2 myPosition;
    [SerializeField] MyVector2 velocity;
    [SerializeField] MyVector2 acceleration;

    [Header("Gravitational Force")]
    [SerializeField] float myMass = 2;
    [SerializeField] float otherMass = 10;
    [SerializeField] Transform otherObj;
    MyVector2 fGravitacional;

    private void Start() {
        myPosition = myPosition.convert(transform.position);
    }

    private void Update() {
        // Draw vectors
        acceleration.DrawVector(myPosition, Color.blue);
        velocity.DrawVector(myPosition, Color.green);
        myPosition.DrawVector(Color.red);

        // Calculate and update position
        UpdatePosition();
        transform.position = new Vector3(myPosition.x, myPosition.y);
    }

    public void UpdatePosition() {
        // Calculate the distance and direction for the gravity force
        MyVector2 gravityDirection = MyVector2.FromUnityVector(otherObj.position - transform.position);
        float distance = gravityDirection.sacarMagnitud();
        gravityDirection = gravityDirection.normalizar();

        // Calculate the gravity force
        if (distance > 0.1) fGravitacional = gravityDirection * (otherMass * myMass / distance * distance);
        else acceleration = gravityDirection;

        // Calculate new acceleration, velocity and position
        acceleration = ApplyForce(fGravitacional, myMass);
        velocity = velocity + acceleration * Time.deltaTime;
        myPosition = myPosition + velocity * Time.deltaTime;
    }

    MyVector2 ApplyForce(MyVector2 force, float mass)
    {
        return force * (1 / mass);
    }
}
