using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileScript1 : BulletScript {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;

	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		if (target != null) {

			Vector3 dir = target.position - myTransform.position;
			dir.z = 0.0f;
			if (dir != Vector3.zero) {
				myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.FromToRotation (Vector3.down, dir), rotationSpeed * Time.deltaTime);
			}

			myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Bullet1") == true) {
			Destroy (gameObject);
		}
	}

}
