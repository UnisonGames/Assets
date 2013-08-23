using UnityEngine;
using System.Collections;

public class movementCam : MonoBehaviour {
	public float speed = 2.0f;
	public float horBound;
	public float verBound;

	public GameObject player;

	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	void Update () {
		float translationY = Input.GetAxis("VerticalY")* speed;
		float translationX = Input.GetAxis("HorizontalX") * speed;
		translationX *= Time.deltaTime;
		translationY *= Time.deltaTime;
		if((player.transform.position.z + translationY) <= verBound && (player.transform.position.z + translationY) >= (-1 * verBound)){
			transform.Translate(0, 0, translationY);
		}
		if((player.transform.position.x + translationX)  <= horBound && (player.transform.position.x + translationX) >= (-1 * horBound)){
			transform.Translate(translationX, 0, 0);
		}
		
	}

}

