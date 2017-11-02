using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {

	private int score = 0;
	public Text ScoreTextBox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//handle the pickup
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") //if collision with player
		{
			Debug.Log ("Touched Player");
			collision.gameObject.GetComponent<PlayerController> ().AddFollower (); //add a follower to the chain
			score++;
			ScoreTextBox.text = "Score: " + score;

			transform.position = new Vector3 (Random.Range (-24, 24), .5f, Random.Range (-24, 24)); //move the pickup to a random position
			//Destroy (this.gameObject);
		}
	}
}
