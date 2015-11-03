using UnityEngine;
using System.Collections;

public class Server : MonoBehaviour {
	public int[][] game1Solution; 
	public int[][] game1Blanks;
	public int[][] serverRepo;

	// Use this for initialization
	void Awake () {
		game1Blanks = new int[][] {
			new int[] {0,0,5,0,0,2,0,0,0},
			new int[] {1,0,0,0,0,0,4,6,0},
			new int[] {2,0,0,0,0,1,0,8,0},
			new int[] {3,0,2,0,0,0,0,1,9},
			new int[] {0,0,8,0,0,3,0,0,0},
			new int[] {0,0,0,0,5,7,0,0,0},
			new int[] {5,0,3,0,6,0,2,0,0},
			new int[] {0,0,7,0,2,0,9,0,6},
			new int[] {0,0,0,8,0,5,0,0,0}
		};
		
		game1Solution = new int[][] {
			new int[] {6,8,5,7,4,2,3,9,1},
			new int[] {1,7,9,5,3,8,4,6,2},
			new int[] {2,3,4,6,9,1,5,8,7},
			new int[] {3,5,2,4,8,6,7,1,9},
			new int[] {7,9,8,2,1,3,6,4,5},
			new int[] {4,6,1,9,5,7,8,2,3},
			new int[] {5,4,3,1,6,9,2,7,8},
			new int[] {8,1,7,3,2,4,9,5,6},
			new int[] {9,2,6,8,7,5,1,3,4}
		};

		serverRepo = game1Blanks;
	}

	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
