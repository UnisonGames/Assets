using UnityEngine;
using System.Collections;

public class input : MonoBehaviour {
	
	public float rotationSpeed = 75.0f;
	float currentRot = 0f;
	float rotFactor;
	float theta;
	
	void Start () {

	}
	
	void Update () {
		float rotX = Input.GetAxis("RotateX");
		float rotY = Input.GetAxis("RotateY");
	 	theta = (Mathf.Atan2(rotY, rotX) * Mathf.Rad2Deg);
		rotFactor = (theta - currentRot);
		if (rotFactor < 0){
			rotFactor += 360;
		}

		if(Mathf.Abs(rotX) + Mathf.Abs(rotY) > .3){
			transform.Rotate(0, rotFactor, 0);
			currentRot = theta;
		}
		rotFactor = 0f;
		theta = 0f;

	}

}
