using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public float speed = 2.0f;
	void Start () {
	
	}
	
	void Update () {
		float translationY = Input.GetAxis("VerticalY")* speed;
		float translationX = Input.GetAxis("HorizontalX") * speed;
		translationX *= Time.deltaTime;
		translationY *= Time.deltaTime;
		transform.Translate(0, 0, translationY);
		transform.Translate(translationX, 0, 0);
		
	}
}
