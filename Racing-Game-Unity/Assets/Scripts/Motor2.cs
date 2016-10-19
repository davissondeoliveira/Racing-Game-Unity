using UnityEngine;
using System.Collections;

public class Motor2 : MonoBehaviour
{

    public Wheel[] wheel;

    public float enginePwr = 50.0f;
    public float turnPwr = 10.0f;
    public float breakForce = 40.0f;
    public float speed;

    private float timeLeft = 4.0f;
    bool start = false;

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 1.0f)
        {
            start = true;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {
            float torquep2 = 0.0f;
            float turnSpeedp2 = 0.0f;
            //Player Two
            if (Input.GetKey(KeyCode.W))
            {
                torquep2 = enginePwr * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                torquep2 = -enginePwr * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                turnSpeedp2 = -turnPwr * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                turnSpeedp2 = turnPwr * speed;
            }

            wheel[0].Move(torquep2);
            wheel[1].Move(torquep2);
            wheel[2].Move(torquep2);
            wheel[3].Move(torquep2);

            wheel[0].Turn(turnSpeedp2);
            wheel[1].Turn(turnSpeedp2);
        }
    }
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Speed Up"))
		{
			other.gameObject.SetActive(false);
			enginePwr = enginePwr + 30.0f;
		}
		if (other.gameObject.CompareTag("Slow Down"))
		{
			other.gameObject.SetActive(false);
			enginePwr = enginePwr - 15.0f;
		}
	}
}
