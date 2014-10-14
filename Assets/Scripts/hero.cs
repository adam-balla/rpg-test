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
	
	
		void OnTriggerEnter2D (Collider2D c)
		{
				if (c.gameObject.name == "01door") {
						Camera.main.transform.position = new Vector3 (0, -13, -1);	
						transform.position = new Vector3 (0.33f, -17f, 0f);
				}
		
				if (c.gameObject.name == "02door") {
						Camera.main.transform.position = new Vector3 (0, 0, -1);	
						transform.position = new Vector3 (-6.60f, -2f, 0f);
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
				Debug.Log (c.gameObject.name);
				if (c.gameObject.name == "OutSide") {
						HeroLayer.sortingOrder = 0;
				}
				if (c.gameObject.name == "InnnerSide") {
						HeroLayer.sortingOrder = 2;
				}
				
				if ((c.name == "NPC") || (c.name == "NPC_1") || (c.name == "NPC_2") || (c.name == "NPC_3") || (c.name == "NPC_4")) {
						if ((c.name == "NPC_1")) {
								HeroLayer.sortingOrder = 2;
								//2
						}
						if ((c.name == "NPC_2")) {
								HeroLayer.sortingOrder = 0;
								//0
						}
						IsNearNPC = true;
						Debug.Log ("NPC");
				} else if (c.name == "NPC_Not") {
						IsNearNPC = false;
				}
		
		}
		bool IsHorizontal;
		bool  IsVertical;
		// Update is called once per frame
		void Update ()
		{
		
//				if (transform .position.y >= -14) {
//						
//				} else if (transform .position.y <= -15) {
//						HeroLayer.sortingOrder = 2;
//				}
		
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
//		Physics.sp
//		Physics2D.
//		if(Physics2D.CircleCast)
				//	Debug.Log (Input.GetAxis ("Vertical").ToString ());
		
		
				//		if (Input.GetKey(KeyCode.DownArrow)) {
				////			transform.position=new Vector3(0,transform.position.y-0.5f);
				//			transform.position=Vector3.Lerp(transform.position,new Vector3(transform.position.x,transform.position.y-0.5f,0),Time.deltaTime*7);
				//		
				//			y=-1;
				//		}
				//
				//		if (Input.GetKey(KeyCode.UpArrow)) {
				//			//			transform.position=new Vector3(0,transform.position.y-0.5f);
				//			transform.position=Vector3.Lerp(transform.position,new Vector3(transform.position.x,transform.position.y+0.5f,0),Time.deltaTime*7);
				//		
				//			y=1;
				//		}
				//
				//		if (Input.GetKey(KeyCode.LeftArrow)) {
				//			//			transform.position=new Vector3(0,transform.position.y-0.5f);
				//			transform.position=Vector3.Lerp(transform.position,new Vector3(transform.position.x-0.5f,transform.position.y),Time.deltaTime*7);
				//
				//			x=-1;
				//		}
				//
				//		if (Input.GetKey (KeyCode.RightArrow)) {
				//			//			transform.position=new Vector3(0,transform.position.y-0.5f);
				//			transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x + 0.5f,transform.position.y), Time.deltaTime *7);
				//
				//			x=1;
				//				
				//         }
				
		}
}