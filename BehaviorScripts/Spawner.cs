using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour {
	/*
	 *(C) Zac Blanco 2013, Unison Game Inc.
	 *
	 *
	 * This Script is designed to spawn a number of objects inside a specific area
	 * 
	 * there are min, and max object settings
	 * min and max spawn time settings
	 * size of the spawn area
	 * and the chances for spawning three different types of AI
	 * 
	 * As of version 0.5 this script does NOT support keeping track of the objects it has spawned
	 * this feature will be added at a later date
	 * For now the script will spawn up to the maximum number of object, then stop.
	 *
	 * */
	
	//types of AI
	public GameObject easyAI;
	public GameObject mediumAI;
	public GameObject toughAI;
	Vector3 trans;
	Vector3 def;
	
	
	GameObject[] spawns;
	
	
	//information for spawner
	int n_AI;
	public int max_AI = 32;
	public int min_AI = 8;
	
	
	//spawn times (Seconds)
	public int minWait = 3;
	public int maxWait = 12;
	float timeSinceSpawn;
	float lastSpawnTime;
	
	//spawn width and height default = 100
	public int spawnSize = 100;
	
	
	//percentages for spawn chance
	public int chanceEasy = 77;
	public int chanceMedium = 19;
	public int chanceTough = 8;
	
	//random Number variables
	int randPos;
	int spawnChance;
	int spawnTime;
	System.Random r = new System.Random(DateTime.Now.Millisecond);

	void Start () {
		spawnTime = r.Next(minWait, maxWait);
		timeSinceSpawn = 0;
		lastSpawnTime = Time.time;
		def = gameObject.transform.position;
		def.y = 3;
		trans = def;
		randPos = 0;
		spawns = new GameObject[max_AI];
	
		
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceSpawn = Time.time - lastSpawnTime;
		spawnChance = r.Next(0, 100);
		if(n_AI < min_AI && timeSinceSpawn > minWait){
			randPos = r.Next(spawnSize);
			trans.x += (-(spawnSize/2)) + randPos;
			randPos = r.Next(spawnSize);
				trans.z += (-(spawnSize/2)) + randPos;
			spawn(spawnChance, trans);
			trans = def;
		}else if(n_AI >= min_AI && n_AI <= max_AI){
			if(timeSinceSpawn > spawnTime){
				randPos = r.Next(spawnSize);
				trans.x += (-(spawnSize/2)) + randPos;
				randPos = r.Next(spawnSize);
				trans.z += (-(spawnSize/2)) + randPos;
				spawn(spawnChance, trans);
				trans = def;	
			}
		}
		
		n_AI = transform.GetChildCount();
	}
	
	
	//this takes the random spawn number argument and spawns an enemy based on the random number
	private void spawn(int spawnNum, Vector3 t){
		if(spawnNum < chanceEasy){
			spawns[n_AI] = (GameObject)Instantiate(easyAI, t, gameObject.transform.rotation);
			spawns[n_AI].transform.parent = transform;
			n_AI++;
			Debug.Log(n_AI);
			lastSpawnTime = Time.time;
			spawnTime = r.Next(minWait, maxWait);
			spawnChance = r.Next(0, 100);
		}else if(spawnNum > chanceEasy && spawnNum < (100 - chanceTough)){
			spawns[n_AI] = (GameObject)Instantiate(mediumAI, t, gameObject.transform.rotation);
			spawns[n_AI].transform.parent = transform;
			n_AI++;
			Debug.Log(n_AI);
			lastSpawnTime = Time.time;
			spawnTime = r.Next(minWait, maxWait);
			spawnChance = r.Next(0, 100);
		}else if(spawnNum > (100-chanceTough)){
			spawns[n_AI] = (GameObject)Instantiate(toughAI, t, gameObject.transform.rotation);
			spawns[n_AI].transform.parent = transform;
			n_AI++;
			lastSpawnTime = Time.time;
			spawnTime = r.Next(minWait, maxWait);
			spawnChance = r.Next(0, 100);
		}else {
			Debug.Log("Error, Spawn Number Out of range");
			
		}
			
		}
}
