using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WheelCollider))]
public class Wheel : MonoBehaviour {
    WheelCollider wc;
    
    void Awake()
    {
        wc = GetComponent<WheelCollider>();
    }

    public void Move(float v)
    {
        wc.motorTorque = v;
    }

    public void Turn(float v)
    {
        wc.steerAngle = v;
    }

}
