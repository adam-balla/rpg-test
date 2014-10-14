using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour
{
		public Transform[] waypoints;
		public float waypointRadius = 1.5f;
		public float damping = 0.1f;
		public bool loop = false;
		public float speed = 2.0f;
		public bool faceHeading = true;
		private Vector3 currentHeading, targetHeading;
		private int targetwaypoint;
		private Transform xform;
		private bool useRigidbody;
		private Rigidbody rigidmember;
		
		
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (hero.IsTalking) {
						return;
				}
				transform.position += currentHeading * Time.deltaTime * speed;
		}
		// calculates a new heading
		protected void FixedUpdate ()
		{
				if (hero.IsTalking) {
						return;
				}
				targetHeading = waypoints [targetwaypoint].position - transform.position;
				currentHeading = Vector3.Lerp (currentHeading, targetHeading, damping * Time.deltaTime);
				
				if (Vector3.Distance (transform.position, waypoints [targetwaypoint].position) <= waypointRadius) {
			
			
						targetwaypoint++;
//						Debug.Log ("Check : " + targetwaypoint + " : " + waypoints.Length);
						if (targetwaypoint >= waypoints.Length) {
								targetwaypoint = 0;
				
//								Debug.Log ("Check 2");
								if (!loop) {
										enabled = false;
								}
						}
				}
		}
}
