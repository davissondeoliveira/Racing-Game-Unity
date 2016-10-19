using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

    public Wheel[] wheel;
    
    public float enginePwr = 50.0f;
    public float turnPwr = 10.0f;
    public float breakForce = 40.0f;
    public float speed;


    // Update is called once per frame
    void FixedUpdate () {
        //float torque = Input.GetAxis("Vertical") * enginePwr;
        //float turnSpeed = Input.GetAxis("Horizontal") * turnPwr;

        float torque = 0.0f;
        float turnSpeed = 0.0f;

        //Player One
        if (Input.GetKey(KeyCode.UpArrow))
        {
            torque = enginePwr * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            torque = -enginePwr * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnSpeed = -turnPwr * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turnSpeed = turnPwr * speed;
        }

        wheel[0].Move(torque);
        wheel[1].Move(torque);
        wheel[2].Move(torque);
        wheel[3].Move(torque);

        wheel[0].Turn(turnSpeed);
        wheel[1].Turn(turnSpeed);

    }

 
}
