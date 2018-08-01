using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject Bullet1;
	public GameObject Bullet2;
	public Transform bulletSpawn;
	public float MoveSpeed;
	public float rotateSpeed;
	public float Health;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		Vector3 movement;

		if (rotateSpeed == 0) {
			movement = new Vector3 (x, y, 0.0f);
		} else {
			movement = new Vector3 (0, y, 0.0f);
		}

		Vector3 rotation = new Vector3 (0.0f, 0.0f, -x);
		transform.Rotate (rotation*rotateSpeed);
		transform.Translate (movement*MoveSpeed);

		if (Input.GetKeyDown(KeyCode.Joystick1Button0)||Input.GetKeyDown(KeyCode.Space))
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

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "HomingMissile") {
			Destroy (gameObject);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

}
