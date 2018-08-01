﻿using UnityEngine;
using System.Collections;

public class Enemy1Controller : EnemyScript {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public float Health;

	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {

		//GameObject go = GameObject.FindGameObjectWithTag ("Player");

		//target = go.transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = target.position - myTransform.position;
		dir.z = 0.0f;
		if (dir != Vector3.zero)
			{
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.FromToRotation(Vector3.down, dir), rotationSpeed * Time.deltaTime);
			}

		myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;

	}


}
