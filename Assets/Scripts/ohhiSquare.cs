using UnityEngine;
using System.Collections;

public class ohhiSquare : MonoBehaviour
{

		//public Color currentColor;
		public Color blankColor;
		public Color firstColor;
		public Color secondColor;
		public int state;
		public int correctState;
		public int ID;
        public int count;
		public ohhiGameBoard ohhiGameBoard;
		public bool Playable;
		public bool Selected;
		public bool isCorrect;
		public bool highlighted;
		public float highlightSize = 1.2f;

		void Start ()
		{
			ohhiGameBoard = GetComponentInParent<ohhiGameBoard>();
		}
	
		void Update ()
		{
			CheckHighlight();
			CheckCorrect();

			if (highlighted && ohhiGameBoard.changeColorNow) {
				ChangeColor();
                ohhiGameBoard.changeColorNow = false;
			}

			switch (state) {
				case 1:
					GetComponent<Renderer>().material.color = firstColor;
					break;
				case 2: 
					GetComponent<Renderer>().material.color = secondColor;
					break;
				case 0:
					GetComponent<Renderer>().material.color = blankColor;
					break;
				default:
					Debug.Log ("no valid color");
					break;
			}
		}
	
		public void OnMouseDown() {
			ChangeColor ();
		}
		
	public void ChangeColor () {
		if (Playable) {
			if (state < 2) {
				state++;
			} else {
				state = 0;
			}
		}
	}	 

	public void CheckCorrect() {
		if (state == correctState) {
			isCorrect = true;
		}
	}

	public void CheckHighlight() {
		if (ID == ohhiGameBoard.highlightedSquare) {
			highlighted = true;
			gameObject.transform.localScale = new Vector3(highlightSize,highlightSize,1f);
		} else {
			highlighted = false;
			gameObject.transform.localScale = new Vector3(1f,1f,1f);
		}
	}


	public void OnMouseOver() {
		highlighted = true;
	}

	public void OnMouseExit() {
		highlighted = false;
	}
}
