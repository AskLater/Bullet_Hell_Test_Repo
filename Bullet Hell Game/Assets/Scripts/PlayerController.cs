using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var x = Input.GetAxis ("Horizontal");
		var y = Input.GetAxis ("Vertical");

		transform.Rotate (0, 0, -x);
		transform.Translate(x, y, 0);

	}
}
