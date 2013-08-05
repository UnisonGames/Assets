using UnityEngine;
using System.Collections;
using System;

public class Spawner_Easy : MonoBehaviour {
	
	
	//types of AI
	public GameObject easyAI;
	public GameObject mediumAI;
	public GameObject toughAI;
	GameObject me;
	
	//information for spawner
	int n_AI;
	public int max_AI = 32;
	public int min_AI = 8;
	
	
	public int minWait = 3;
	public int maxWait = 12;
	float timeSinceSpawn;
	float lastSpawnTime;
	
	
	
	//percentages for spawn chance
	public int chanceEasy = 77;
	public int chanceMedium = 19;
	public int chanceTough = 8;
	
	//random Number variables
	int spawnChance;
	int spawnTime;
	System.Random r = new System.Random(DateTime.Now.Millisecond);

	void Start () {
	spawnTime = r.Next(minWait, maxWait);
	timeSinceSpawn = 0;
	lastSpawnTime = Time.time;
	me = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceSpawn = Time.time - lastSpawnTime;
		spawnChance = r.Next(0, 100);
		if(n_AI < min_AI && timeSinceSpawn > minWait){
			spawn(spawnChance);
		}else if(n_AI >= min_AI && n_AI <= max_AI){
			if(timeSinceSpawn > spawnTime){
				spawn(spawnChance);
			}
		}
	}
	
	
	//this takes the random spawn number argument and spawns an enemy based on the random number
	private void spawn(int spawnNum){
		if(spawnNum < chanceEasy){
			Instantiate(easyAI, gameObject.transform.position, gameObject.transform.rotation);
			n_AI++;
			lastSpawnTime = Time.time;
			spawnTime = r.Next(minWait, maxWait);
			spawnChance = r.Next(0, 100);
		}else if(spawnNum > chanceEasy && spawnNum < (100 - chanceTough)){
			Instantiate(mediumAI, gameObject.transform.position, gameObject.transform.rotation);
			n_AI++;
			lastSpawnTime = Time.time;
			spawnTime = r.Next(minWait, maxWait);
			spawnChance = r.Next(0, 100);
		}else if(spawnNum > (100-chanceTough)){
			Instantiate(toughAI, gameObject.transform.position, gameObject.transform.rotation);
			n_AI++;
			lastSpawnTime = Time.time;
			spawnTime = r.Next(minWait, maxWait);
			spawnChance = r.Next(0, 100);
		}else {
			Debug.Log("Error, Spawn Number Out of range");
			
		}
			
		}
}
