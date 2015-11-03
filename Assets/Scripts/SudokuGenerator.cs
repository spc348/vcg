using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SudokuGenerator : MonoBehaviour
{
    int[][] faceValues;
    GameObject[][] board;
    SudokuSquare sudokuSquare;
    public GameObject Cell;
    public GameObject target;
    bool firstRun;
    int counter;

    void Awake()
    {
        Cell.transform.position = target.transform.position;
        firstRun = false;
    }

    void GenerateBoard()
    {
        int n = 3;
        for (int i = 0; i < n * n; i++)
        {
            for (int j = 0; j < n * n; j++)
            {
                faceValues[i][j] = (i * n + i / n + j) % (n * n) + 1;
            }
        }
    }

    void InitArrays()
    {
        board = new GameObject[][]
				        {
							new GameObject[9],
							new GameObject[9],
							new GameObject[9],
							new GameObject[9],
							new GameObject[9],
							new GameObject[9],
							new GameObject[9],
							new GameObject[9],
							new GameObject[9]
				        };

        faceValues = new int[][]
						{
							new int[9],
							new int[9],
							new int[9],
							new int[9],
							new int[9],
							new int[9],
							new int[9],
				            new int[9],
				            new int[9]
				        };
    }

    void InsertRandomN()
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                counter++;
                var obj = Instantiate(Cell, new Vector3(i * 2f, j * 2f), Quaternion.identity) as GameObject;
                obj.transform.parent = gameObject.transform;
                sudokuSquare = obj.GetComponent<SudokuSquare>();
                if (sudokuSquare)
                {
                   sudokuSquare.correctNum = faceValues[i][j];
                   sudokuSquare.ID = counter;
                }
                else
                    Debug.Log("help");
            }
        }
    }

    void Update()
    {
        if (!firstRun)
        {
            InitArrays();
            GenerateBoard();
            InsertRandomN();
            firstRun = true;
        }
    }
}
