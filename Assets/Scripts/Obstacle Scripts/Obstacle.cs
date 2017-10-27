//obstacle Script
using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public float savedtime = 0;
    public float TimeDelay = 30f;
	public float speed = -7f ;
	public Rigidbody2D myBody;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
          if(((Time.time) - (savedtime)) > TimeDelay ) { 
              savedtime = Time.time; //reset the saved time
              myBody.velocity = new Vector2 (speed, 0f);
              speed += (-1.0f); // += will allow your speed var to accumulate
          }
		  else{
			   myBody.velocity = new Vector2 (speed, 0f);
		  }
	}
}

  
 
     
