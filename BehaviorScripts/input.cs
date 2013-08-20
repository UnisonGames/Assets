using UnityEngine;
using System.Collections;

public class input : MonoBehaviour {
	
	public float speed = 2.0f;
	public float rotationSpeed = 75.0f;
	float currentRot = 0f;
	float rotFactor;
	float theta;
	
	void Start () {

	}
	
	void Update () {
		float translationY = Input.GetAxis("VerticalY")* speed;
		float translationX = Input.GetAxis("HorizontalX") * speed;
		float rotX = Input.GetAxis("RotateX");
		float rotY = Input.GetAxis("RotateY");
	 	theta = (Mathf.Atan2(rotY, rotX) * Mathf.Rad2Deg);
		rotFactor = (theta - currentRot);
		if (rotFactor < 0){
			rotFactor += 360;
		}
		translationX *= Time.deltaTime;
		translationY *= Time.deltaTime;
		transform.Translate(0, 0, translationY);
		transform.Translate(translationX, 0, 0);
		if(Mathf.Abs(rotX) + Mathf.Abs(rotY) > .3){
			transform.Rotate(0, rotFactor, 0);
			currentRot = theta;
		}


	}
	public void OnGUI(){
		GUI.Label(new Rect(50, 40, 100, 20), "RX " + Input.GetAxis("RotateX"));
		GUI.Label(new Rect(50, 60, 100, 20), "RY " + Input.GetAxis("RotateY"));
		GUI.Label(new Rect(50, 80, 100, 20), "Rf " + rotFactor);
		GUI.Label(new Rect(50, 100, 100, 20), "Theta " + theta);
		rotFactor = 0f;
		theta = 0f;
	}
}
