using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Transform FollowerPrefab;
	private List<GameObject> FollowerList;
	private float rotation = 0f;

	// Use this for initialization
	void Start () {
		FollowerList = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//handle input
		rotation = 0f;
		if (Input.GetAxis ("Horizontal") > 0) 
		{
			rotation += 1f; //rotate right
		} 
		else 
		{
			if (Input.GetAxis ("Horizontal") < 0) 
			{
				rotation-= 1f; //rotate left

			}
		}
		transform.Rotate (new Vector3(0,rotation,0));

		gameObject.transform.Translate (Vector3.forward * 5f *Time.deltaTime); //move forward

	}
	//add a follower to the chain
	public void AddFollower()
	{
		Transform t = (Transform)Instantiate (FollowerPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
		if (FollowerList.Count > 0) //if there are already followers, target the last follower
		{
			t.GetComponent<Follower> ().Target = FollowerList[FollowerList.Count - 1];
			t.transform.position = t.GetComponent<Follower> ().Target.transform.position;
		}
		else //else, target the player
		{
			t.GetComponent<Follower> ().Target = this.gameObject;
			t.transform.position = this.gameObject.transform.position;

		}
		FollowerList.Add(t.gameObject);
	}
}
