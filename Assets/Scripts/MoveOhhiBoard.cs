using UnityEngine;
using System.Collections;

public class MoveOhhiBoard : MonoBehaviour
{
	
		Vector3 OffCamera;
		Vector3 OnCamera;
		Vector3 NextPosition;
	
		float smooth;
	
		void Awake ()
		{
				NextPosition = transform.position;
		}
	
		void MoveBoard ()
		{
				smooth = 5f;
				OffCamera = new Vector3 (0, -8, 0);
				OnCamera = new Vector3 (0, -3, 0);
		
				if (Input.GetKeyDown (KeyCode.Z)) {
						NextPosition = OffCamera;
				}
				if (Input.GetKeyDown (KeyCode.X)) {
						NextPosition = OnCamera;
				}
		
				transform.position = Vector3.Lerp (transform.position, NextPosition, smooth * Time.deltaTime);
		
		}
	
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				MoveBoard ();
		}
}
