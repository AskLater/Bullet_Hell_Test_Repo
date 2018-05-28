using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject Bullet1;
	public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var x = Input.GetAxis ("Horizontal");
		var y = Input.GetAxis ("Vertical");

		transform.Rotate (0, 0, -x);
		transform.Translate(x, y, 0);

		if (Input.GetKeyDown(KeyCode.Joystick1Button0)||(Input.GetKeyDown(KeyCode.Space)))
		{
			Fire();
		}

	}

	void Fire ()
	{
		var bullet = (GameObject)Instantiate (Bullet1, bulletSpawn.position, bulletSpawn.rotation);

		bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.up * 60;

		Destroy (bullet, 2.0f);
	}

}
