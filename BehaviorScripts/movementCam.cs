using UnityEngine;
using System.Collections;

public class movementCam : MonoBehaviour {
	public float speed = 2.0f;
	public bool horMove;
	public bool verMove;
	void Start () {
		horMove = true;
		verMove = true;
	}
	
	void Update () {
		float translationY = Input.GetAxis("VerticalY")* speed;
		float translationX = Input.GetAxis("HorizontalX") * speed;
		translationX *= Time.deltaTime;
		translationY *= Time.deltaTime;
		if(verMove){
		transform.Translate(0, 0, translationY);
		}
		if(horMove){
		transform.Translate(translationX, 0, 0);
		}
		
	}
void OnCollisionStay(Collision other){
		if (other.gameObject.CompareTag("HorizontalWall")){
			horMove = false;
		}else{
			horMove = true;	
	}
		if (other.gameObject.CompareTag("VerticalWall")){
			verMove = false;
		}else{
			verMove = true;	
	}
}

}

