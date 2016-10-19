using UnityEngine;
using System.Collections;

public class camFollow : MonoBehaviour {

	public Transform target;
	
	// Update is called once per frame
	void LateUpdate () {
		//it will be handled after all the updates
		transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
	}
}
