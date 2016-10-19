using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    private bool finished1 = false;
	private bool finished2 = false;
    private bool stop = true;

    public int laps1 = 1, laps2 = 1;
	public int countLaps1 = -1, countLaps2 = -1;

    private Color color;
    private GUIStyle guiStyleLabel = new GUIStyle();
	private GUIStyle style = new GUIStyle();
	private GUIStyle styleLap = new GUIStyle();

    string timeLeftS;
    string timeRightS;

    private float timeLeft = 4.0f;
    private float timeRight = 0.0f;
    public bool start;
    
    void Start()
    {
        start = false;
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftS = ((int)timeLeft).ToString();

        if (timeLeft < 1.0f)
        {
            timeLeftS = "GO";
            if (timeLeft <= 0.0f)
            {
                timeLeftS = "";
                start = true;
                if (start)
                {
                    if (stop)
                    {
                        UpdateTimerUI();
                    }
                }
            }
        }

    }

    //public int width, height;
    // Update is called once per frame
    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag("Tag2"))
		{
			countLaps2++;

            if (laps2 < 1)
            {
                finished1 = true;
            }
            laps2--;
        }
        if (other.gameObject.CompareTag("Tag1"))
        {
			countLaps1++;

            if (laps1 < 1)
            {
                finished2 = true;
            }
            laps1--;
        }
    }
    void OnGUI()
    {
		
		string cl2 = checkLaps(countLaps2);
		string cl1 = checkLaps(countLaps1);
		styleLap.fontSize = 20;
		styleLap.normal.textColor = Color.white;
		GUI.Label(new Rect((Screen.width - 45), ((Screen.height / 2)- 30) , 600, 100), cl1, styleLap);
		GUI.Label(new Rect((Screen.width - 45), (Screen.height - 30) , 600, 100), cl2, styleLap);


        style.fontSize = 50;
        style.normal.textColor = Color.white;
		GUI.Label(new Rect((Screen.width / 2) - 30, (Screen.height / 2) - 30 , 600, 100), timeLeftS, style);
        GUI.Label(new Rect(5, 10, 600, 100), timeRightS);

        guiStyleLabel.fontSize = 20;
        guiStyleLabel.normal.textColor = Color.red;

		if (finished2) {
			GUI.Label (new Rect (((Screen.width / 2) - 47), ((Screen.height / 4) - 40), 600, 100), "You WON", guiStyleLabel);
			GUI.Label (new Rect (((Screen.width / 2) - 57), ((Screen.height / 2) + 50), 600, 100), "You LOOOOOST", guiStyleLabel);
			if (GUI.Button (new Rect (((Screen.width / 2) - 50), ((Screen.height / 4) + 20), 100, 40), "Restart")) {
				Application.LoadLevel ("CarRace");
			}
			stop = finished1 = false;
		}

		if (finished1) {
			GUI.Label (new Rect (((Screen.width / 2) - 57), ((Screen.height / 2) + 50), 600, 100), "You WON", guiStyleLabel);
			GUI.Label (new Rect (((Screen.width / 2) - 45), ((Screen.height / 4) - 40), 600, 100), "You LOOOOOST", guiStyleLabel);
			if (GUI.Button (new Rect (((Screen.width / 2) - 50), ((Screen.height / 4) + 20), 100, 40), "Restart")) {
				Application.LoadLevel ("CarRace");
			}
            stop = finished2 = false;
		}
    }
    public void UpdateTimerUI()
    {
        //set timer UI
        timeRight += Time.deltaTime;
        timeRightS = Mathf.Floor(timeRight / 60).ToString("00") + ":" + Mathf.RoundToInt(timeRight % 60).ToString("00") + "." + Mathf.Floor((timeRight * 100) % 100).ToString("00");
    }

	private string checkLaps(int x){
		if(x==6){
			return "Final";
		}
		if(x==4){
			return "Final";
		}
		if(x==2){
			return "Final";
		}else{
			return "Lap1";
		}

	}
}
