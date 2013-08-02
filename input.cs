using UnityEngine;
using System.Collections;

public class input : MonoBehaviour {
	
	public float speed = 2.0f;
	public float rotationSpeed = 75.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float translationY = Input.GetAxis("VerticalY")* speed;
		float translationX = Input.GetAxis("HorizontalX") * speed;
		float rotation = Input.GetAxis("Rotate");
		translationX *= Time.deltaTime;
		translationY *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translationY);
		transform.Translate(translationX, 0, 0);
		transform.Rotate(0, rotation, 0);
	
	}
}
