using UnityEngine;
using System.Collections;
using System;
public class Typing : MonoBehaviour
{
		public string textShownOnScreen;
		string fullText = "hi,/this is text";
		public float wordsPerSecond = 2; // speed of typewriter
		private float timeElapsed = 0;   
		int count;
		public TextMesh Text;
		public	Rect Tap;
		float Speed = 0.2f;
		float time;
		bool IsOnce;
		
		void Start ()
		{
				Text.text = "";
				InvokeRepeating ("TypeWord", Speed, Speed);
				
		}
		void Update ()
		{
//				timeElapsed += Time.deltaTime;
//				count = (int)(timeElapsed * wordsPerSecond);
//				textShownOnScreen = GetWords (fullText, count);
//				Text.text = textShownOnScreen;

				if (Input.GetMouseButtonDown (0)) {
						
						
				}
				if (Input.GetMouseButton (0)) {
//						if (timeElapsed > 0.3f && !IsOnce) {
//								IsOnce = true;
//								CancelInvoke ("TypeWord");
//								Speed = 0.1f;
//								InvokeRepeating ("TypeWord", Speed, Speed);
//						}
//						
//						timeElapsed += Time.deltaTime;
//						Debug.Log ("Time : " + timeElapsed);
						
				}
				
				if (Input.GetKeyDown (KeyCode.Space) && (hero.IsTyping)) {
			
//						timeElapsed = 0;
//						Speed = 0.5f;
//						IsOnce = true;
//						CancelInvoke ("TypeWord");
//						InvokeRepeating ("TypeWord", Speed, Speed);
						
						CancelInvoke ("TypeWord");
						Text.text = fullText.Replace ("/", "\n");
						
				}
//				if (Input.GetMouseButtonUp (0) && (timeElapsed < 1f)) {
//						timeElapsed = 0;
//						Speed = 0.5f;
//						IsOnce = true;
//						CancelInvoke ("TypeWord");
//						InvokeRepeating ("TypeWord", Speed, Speed);
//						if (Tap.Contains (Input.mousePosition)) {
//								CancelInvoke ("TypeWord");
//								Text.text = fullText.Replace ("/", "\n");
//						}
//
//				}
				
		}
		int wordsCount;
		void TypeWord ()
		{
				if (fullText.Length > wordsCount) {
						if (fullText [wordsCount] == ' ') {
								Text.text += fullText [wordsCount];
								wordsCount++;
				
						} else if (fullText [wordsCount] == '/') {
								Text.text += "\n";
								wordsCount++;
								Debug.Log ("hhhhhh");
						}
						Text.text += fullText [wordsCount];
						Debug.Log (fullText [wordsCount]);
						wordsCount++;
				} else {
						CancelInvoke ("TypeWord");
				}
		}
	
		private string GetWords (string text, int wordCount)
		{
				int words = wordCount;
		
				// loop through each character in text
				for (int i = 0; i < text.Length; i++) { 
						if (text [i] == ' ') {
								words--;
						}
						if (text [i] == '-') {
								Debug.Log ("check");
								
								words--;
								text = text.Substring (0, (i)) + "\n";
						} else if (words <= 0) {
								Debug.Log ("check 1");
								return text.Substring (0, i);
						}
				}
		
				return text;
		}
}
