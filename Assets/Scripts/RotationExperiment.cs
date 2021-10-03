using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExperiment : MonoBehaviour
{
    [SerializeField] [Range(0, 360)] float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(3, 0, 0);
        Quaternion quaternion = Quaternion.Euler(0.0f, 0.0f, rotation);
        Matrix4x4 rotered =Matrix4x4.Rotate(quaternion);
        transform.position = rotered * transform.position;

    }
}
