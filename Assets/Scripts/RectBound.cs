using UnityEngine;
using System.Collections;

public class RectBound : MonoBehaviour
{

//		public static Rect GUIRectWithObject (GameObject go)
//		{
//				Vector3 cen = go.renderer.bounds.center;
//				Vector3 ext = go.renderer.bounds.extents;
//				Vector2[] extentPoints = new Vector2[8]
//		{
//			HandleUtility.WorldToGUIPoint (new Vector3 (cen.x - ext.x, cen.y - ext.y, cen.z - ext.z)),
//			HandleUtility.WorldToGUIPoint (new Vector3 (cen.x + ext.x, cen.y - ext.y, cen.z - ext.z)),
//			HandleUtility.WorldToGUIPoint (new Vector3 (cen.x - ext.x, cen.y - ext.y, cen.z + ext.z)),
//			HandleUtility.WorldToGUIPoint (new Vector3 (cen.x + ext.x, cen.y - ext.y, cen.z + ext.z)),
//			
//			HandleUtility.WorldToGUIPoint (new Vector3 (cen.x - ext.x, cen.y + ext.y, cen.z - ext.z)),
//			HandleUtility.WorldToGUIPoint (new Vector3 (cen.x + ext.x, cen.y + ext.y, cen.z - ext.z)),
//			HandleUtility.WorldToGUIPoint (new Vector3 (cen.x - ext.x, cen.y + ext.y, cen.z + ext.z)),
//			HandleUtility.WorldToGUIPoint (new Vector3 (cen.x + ext.x, cen.y + ext.y, cen.z + ext.z))
//		};
//		
//				Vector2 min = extentPoints [0];
//				Vector2 max = extentPoints [0];
//		
//				foreach (Vector2 v in extentPoints) {
//						min = Vector2.Min (min, v);
//						max = Vector2.Max (max, v);
//				}
//		
//				return new Rect (min.x, min.y, max.x - min.x, max.y - min.y);
//		}

		public	Rect rect;
		public bool isShow;
		void Start ()
		{
				rect = BoundsToScreenRect (gameObject.renderer.bounds);
				GetComponent<Typing> ().Tap = rect;
		}

		public Rect BoundsToScreenRect (Bounds bounds)
		{
				// Get mesh origin and farthest extent (this works best with simple convex meshes)
				Vector3 origin = Camera.main.WorldToScreenPoint (new Vector3 (bounds.min.x, bounds.max.y, 0f));
				Vector3 extent = Camera.main.WorldToScreenPoint (new Vector3 (bounds.max.x, bounds.min.y, 0f));
		
				// Create rect in screen space and return - does not account for camera perspective
				return new Rect (origin.x, Screen.height - origin.y, extent.x - origin.x, origin.y - extent.y);
		}
		
		void OnGUI ()
		{
				if (isShow) {
						GUI.Box (rect, gameObject.name);
				}
		}
}
