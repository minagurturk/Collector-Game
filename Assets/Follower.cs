using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

	public GameObject Target;
	public float offset = 12f;
	private Vector3 targetPrevPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Target != null) 
		{
			if (Vector3.Distance (transform.position, Target.transform.position) > offset) 
			{
				transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, 5f * Time.deltaTime);
			}
			//if the distance between follower and target is bigger than offset, move towards target

		}
	}
}
