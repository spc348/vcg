using UnityEngine;
using System.Collections;

public class Sudoku_Gameboard : MonoBehaviour
{

    public int highlightedSquare, numToPlace, cell;
    public bool placeNum;
	public bool isCompleteAndCorrect;
	private float startTime;
	public float speed = 1.0f;
	public Server server;
	public SudokuSquare[] sudokuSquares;
	public bool foldBoard;
	public bool unfoldBoard;
	public int[][] game1Solution; 
	public int[][] game1Blanks;
	private int[][] localCode;
	private int[][] localRepo;
	
	void Start()
	{
		highlightedSquare = 1;
		startTime = Time.time;
		foldBoard = true;
		sudokuSquares = GetComponentsInChildren<SudokuSquare>();

		localCode = server.game1Blanks;
		NewGame ();
//		int n = 3;
//		for (int i = 0; i < n * n; i++)
//		{
//			for (int j = 0; j < n * n; j++)
//			{
//				//sudokuSquares[cell].playerAnswer = server.game1Blanks[i][j];
//				sudokuSquares[cell].correctNum = server.game1Solution[i][j];
//				sudokuSquares[cell].row = i;
//				sudokuSquares[cell].col = j;
//				cell++;	
//			}
//		}
	
    
    }

    void Update()
    {

//		print(gameObject.name + " SR: " + server.serverRepo[0][0].ToString());
//		print(gameObject.name + " LC: " + localCode[0][0].ToString());
//		print (gameObject.name + " LR: " + localRepo[0][0].ToString());

		CheckCompleteAndCorrect();

		if (foldBoard) {
			foreach (SudokuSquare ss in sudokuSquares){
				StartCoroutine(ss.fold ());
			}
		} else {
			foreach (SudokuSquare ss in sudokuSquares){
				StartCoroutine(ss.unfold ());
		}
	}

        //if (Input.GetKeyDown("space")) {
        //    foldBoard = !foldBoard;
        //    print ("foldBoard: " + foldBoard);
        //}
	}

	public void NewGame() {
		int n = 3;
		for (int i = 0; i < n * n; i++)
		{
			for (int j = 0; j < n * n; j++)
			{
				//sudokuSquares[cell].playerAnswer = server.game1Blanks[i][j];
				sudokuSquares[cell].correctNum = server.game1Solution[i][j];
				sudokuSquares[cell].row = i;
				sudokuSquares[cell].col = j;
				cell++;	
			}
		}
	}

	public void UpdateLocalCode() {
		localCode = localRepo;
		cell = 0;
		int n = 3;
		for (int i = 0; i < n * n; i++)
		{
			for (int j = 0; j < n * n; j++)
			{
				sudokuSquares[cell].playerAnswer = localCode[i][j];
				cell++;	
			}
		}
	}

	public void Commit() {
		cell = 0;
		int n = 3;
		for (int i = 0; i < n * n; i++)
		{
			for (int j = 0; j < n * n; j++)
			{
				localCode[i][j] = sudokuSquares[cell].playerAnswer; 
				cell++;	
			}
		}

		localRepo = localCode;
		//print ("localRepo = localCode");
	}
	
	public void Push() {
		server.serverRepo = localRepo;
	}

	public void Pull() {
		localRepo = server.serverRepo;
	}

	public void CheckCompleteAndCorrect() {
		isCompleteAndCorrect = true;
		foreach (var square in sudokuSquares)
		{
			if (!square.isCorrect)
			{
				isCompleteAndCorrect = false;
			}
		}
	}


}