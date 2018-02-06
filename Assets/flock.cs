﻿using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {

	public globalFlock myManager;
	public float speed = 0.001f;
	float rotationSpeed = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;
	float neighbourDistance = 2.5f;

	bool turning = false;

	// Use this for initialization
	void Start () 
	{
		speed = Random.Range(0.7f,2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//determine the bounding box of the manager cube
		Bounds b = new Bounds(myManager.transform.position, myManager.swimLimits*2);
		
		//if fish is outside the bounds of the cube then start turning around
		if(!b.Contains(transform.position))
		{
			turning = true;
		}
		else
			turning = false;

		if(turning)
		{
			//turn towards the centre of the manager cube
			Vector3 direction = myManager.transform.position - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation,
					                                  Quaternion.LookRotation(direction), 
					                                  rotationSpeed * Time.deltaTime);
			speed = Random.Range(0.7f,2);
		}
		else
		{
			if(Random.Range(0,5) < 1)
				ApplyRules();
			
		}
		transform.Translate(0, 0, Time.deltaTime * speed);
	}

	void ApplyRules()
	{
		GameObject[] gos;
		gos = myManager.allFish;
		
		Vector3 vcentre = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = 0.1f;
		
		Vector3 goalPos = myManager.goalPos;

		float dist;

		int groupSize = 0;
		foreach (GameObject go in gos) 
		{
			if(go != this.gameObject)
			{
				dist = Vector3.Distance(go.transform.position,this.transform.position);
				if(dist <= neighbourDistance)
				{
					vcentre += go.transform.position;	
					groupSize++;	
					
					if(dist < 1.0f)		
					{
						vavoid = vavoid + (this.transform.position - go.transform.position);
					}
					
					flock anotherFlock = go.GetComponent<flock>();
					gSpeed = gSpeed + anotherFlock.speed;
				}
			}
		} 
		
		if(groupSize > 0)
		{
			vcentre = vcentre/groupSize + (goalPos - this.transform.position);
			speed = gSpeed/groupSize;
			
			Vector3 direction = (vcentre + vavoid) - transform.position;
			if(direction != Vector3.zero)
				transform.rotation = Quaternion.Slerp(transform.rotation,
					                                  Quaternion.LookRotation(direction), 
					                                  rotationSpeed * Time.deltaTime);
		
		}
	}
}
