using UnityEngine;
using System.Collections;

public class input : MonoBehaviour {
	
	public float speed = 2.0f;
	public float rotationSpeed = 75.0f;

	void Start () {
	
	}
	
	void Update () {
		float translationY = Input.GetAxis("VerticalY")* speed;
		float translationX = Input.GetAxis("HorizontalX") * speed;
		float rotationX = Input.GetAxis("RotateX") * rotationSpeed;
		float rotationY = Input.GetAxis("RotateY") * rotationSpeed;
		translationX *= Time.deltaTime;
		translationY *= Time.deltaTime;
		rotationX *= Time.deltaTime;
		rotationY *= Time.deltaTime;
		transform.Translate(0, 0, translationY);
		transform.Translate(translationX, 0, 0);
		transform.Rotate(0, rotationY, 0);
		transform.Rotate(rotationX, 0, 0);
	
	}
}
