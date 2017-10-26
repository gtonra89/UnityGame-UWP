using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private float speed = -9f;

	private Rigidbody2D myBody;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		myBody.velocity = new Vector2 (speed, 0f);
	}
}
