using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour
{

		public Dictionary<GameObject,int> sudValues = new Dictionary<GameObject,int> ();

		public GameObject[] Cells = new GameObject[81];
		
		public bool isCompleteAndCorrect;
		public bool starterSquare;
		public ohhiSquare[] ohhiSquares;
	
		void Start ()
		{
				int cellNum = 0;
				foreach (Transform child in transform) {
						cellNum++;
						child.name = "Cell" + cellNum.ToString ();
				}

				sudValues.Add (Cells [0], 8);
				sudValues.Add (Cells [1], 0);
				sudValues.Add (Cells [2], 2);
				sudValues.Add (Cells [3], 0);
				sudValues.Add (Cells [4], 3);
				sudValues.Add (Cells [5], 0);
				sudValues.Add (Cells [6], 0);
				sudValues.Add (Cells [7], 7);
				sudValues.Add (Cells [8], 5);

				foreach (KeyValuePair<GameObject,int> pair in sudValues) {
						var cell = pair.Key.GetComponent<Cell> ();
						cell.sudValue = pair.Value;
		
				}


		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
