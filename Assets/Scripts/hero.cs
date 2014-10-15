using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour
{
	
		public float x;
		public float y;
		float speed = 12f;
	
		Animator anim;
		bool IsNearNPC;
		public 	GameObject Bubble;
		public static	bool IsTalking;
		SpriteRenderer HeroLayer;
		public Animator Mouse;
		public static bool IsTyping;
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
				HeroLayer = GetComponent<SpriteRenderer> ();
		}


		void onTriggerLeave2D (Collider2D c){
			if (c.gameObject.name == "mouse") {
				IsNearNPC = false;
			}
		}


//----------1.)	NPC és  Player renderelési sorrendje:
		void onTriggerStay2D (Collider2D c){
			if (c.gameObject.name == "mouse") {
				if (c.gameObject.name == "mouse") {
					if (c.gameObject.transform.position.y < this.gameObject.transform.position.y) {
						HeroLayer.sortingOrder = 0;
					} else {
						HeroLayer.sortingOrder = 2;
					}
				}
			}
		}
//--------------------
	
		void OnTriggerEnter2D (Collider2D c)
		{
				if (c.gameObject.name == "01door") {
						Camera.main.transform.position = new Vector3 (0, -13, -1);	
						transform.position = new Vector3 (0.33f, -17f, 0f);
				}
		
				if (c.gameObject.name == "02door") {
						Camera.main.transform.position = new Vector3 (0, 0, -1);	
						transform.position = new Vector3 (-6.60f, -3f, 0f);
				}
				if (c.gameObject.name == "door3") {
						Camera.main.transform.position = new Vector3 (0, -24, -1);	
						transform.position = new Vector3 (-8.5f, -27f, -0.5f);
				}
		
				if (c.gameObject.name == "door4") {
						Camera.main.transform.position = new Vector3 (0, -12, -1);	
						transform.position = new Vector3 (0f, -16.5f, -0.5f);
				}
		
				if (c.gameObject.name == "door5") {
						Camera.main.transform.position = new Vector3 (0, -36, -1);	
						transform.position = new Vector3 (-9f, -36.5f, -0.5f);
				}
		
				if (c.gameObject.name == "door6") {
						Camera.main.transform.position = new Vector3 (0, -24, -1);	
						transform.position = new Vector3 (8.9f, -27.5f, -0.5f);
				}
		
				if (c.gameObject.name == "door7") {
						Camera.main.transform.position = new Vector3 (0, -48, -1);	
						transform.position = new Vector3 (-8.8f, -47f, -0.5f);
				}
		
				if (c.gameObject.name == "door8") {
						Camera.main.transform.position = new Vector3 (0, -36, -1);	
						transform.position = new Vector3 (0.9f, -32.6f, -0.5f);
				}
		
				if (c.gameObject.name == "door9") {
						Camera.main.transform.position = new Vector3 (0, -60, -1);	
						transform.position = new Vector3 (-5.2f, -63.2f, -0.5f);
				}
		
				if (c.gameObject.name == "door10") {
						Camera.main.transform.position = new Vector3 (0, -48, -1);	
						transform.position = new Vector3 (0f, -49f, -0.5f);
				}
		
				if (c.gameObject.name == "door11") {
						Camera.main.transform.position = new Vector3 (0, -72, -1);	
						transform.position = new Vector3 (-5.7f, -74.7f, -0.5f);
				}
				if (c.gameObject.name == "door12") {
						Camera.main.transform.position = new Vector3 (0, -60, -1);	
						transform.position = new Vector3 (6.2f, -62.1f, -0.5f);
				}
//----------2.)	Player és háttérbeli objektumok renderelési sorrendje:
				if (c.gameObject.name == "OutSide") {
						HeroLayer.sortingOrder = 0;
				}
				if (c.gameObject.name == "InnnerSide") {
						HeroLayer.sortingOrder = 2;
				}
//--------------------



//----------1.)	NPC és  Player renderelési sorrendje:
				if (c.gameObject.name == "mouse") {
					IsNearNPC = true;
					if (c.gameObject.name == "mouse") {
						if (c.gameObject.transform.position.y < this.gameObject.transform.position.y) {
							HeroLayer.sortingOrder = 0;
						} else {
							HeroLayer.sortingOrder = 2;
						}
					}
				}
//--------------------

		}

		bool IsHorizontal;
		bool IsVertical;
		// Update is called once per frame
		void Update ()
		{
		
				if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.001) {
						transform.position = Vector3.Lerp (transform.position, transform.position + new Vector3 (0.5f * Input.GetAxis ("Horizontal"), 0, 0), Mathf.Abs (Input.GetAxis ("Horizontal")) * speed * Time.deltaTime);
				}
		
				if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0.001) {
						transform.position = Vector3.Lerp (transform.position, transform.position + new Vector3 (0, 0.5f * Input.GetAxis ("Vertical"), 0), Mathf.Abs (Input.GetAxis ("Vertical")) * speed * Time.deltaTime);
				}
				
		
				anim.SetFloat ("x", Input.GetAxis ("Horizontal"));
		
				anim.SetFloat ("y", Input.GetAxis ("Vertical"));
				if (Input.GetKeyDown (KeyCode.Space) && (IsNearNPC)) {
						Bubble.SetActive (true);
						IsTalking = true;
						IsTyping = true;
						Mouse.SetBool ("IsIdle", true);
				}
				
				if (IsTalking) {
						Mouse.transform.eulerAngles = new Vector3 (0, 0, 0);
				}
				
		}
}