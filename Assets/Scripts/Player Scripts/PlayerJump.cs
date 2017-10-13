using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	[SerializeField]
	private AudioClip jumpClip; //declare variables

	private float jumpForce = 9f, forwardForce = 0f; //assign jump variables 

	private Rigidbody2D myBody;

	private bool canJump;  // jump boolean

	private Button jumpBtn; //button variable
	
	void Awake () {
		myBody = GetComponent<Rigidbody2D> (); //assign mybody to the rigidbody of the player object 

		jumpBtn = GameObject.Find ("Jump Button").GetComponent<Button> (); // find the game object jump button

		jumpBtn.onClick.AddListener (() => Jump());
	}

	void Update () {
		if(Mathf.Abs(myBody.velocity.y) == 0) {
			canJump = true;
		}
	}

	public void Jump() {
		if (canJump) {
			
			canJump = false;

			//AudioSource.PlayClipAtPoint(jumpClip, transform.position);

			if(transform.position.x < 0) {
				forwardForce = 4f;
			} else {
				forwardForce = 0f;
			}

			myBody.velocity = new Vector2(forwardForce, jumpForce);

		}
	}

	 
} 



















































