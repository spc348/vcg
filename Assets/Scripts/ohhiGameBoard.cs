using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ohhiGameBoard : MonoBehaviour
{
    public bool isCompleteAndCorrect, starterSquare, changeColorNow;
    public ohhiSquare[] ohhiSquares;
    public GameObject newSquare;
    public int highlightedSquare, counter, previous_r_2, c;
    public Vector3 showPos, hidePos, next;
    public float smooth;
	//public Dictionary <int[],int[]> ohhiGames = new Dictionary<int[],int[]>();



	int[][,] ohhiGames = new int[5][,] 
	{
		new int[,] { {0,0,0,1, 2,0,0,0, 0,0,2,0, 2,0,0,2}, {1,2,2,1, 2,2,1,1, 1,1,2,2, 2,1,1,2 } },
		new int[,] { {1,0,0,0, 0,0,0,0, 0,2,0,2, 0,0,0,2}, {1,2,2,1, 2,1,2,1, 1,2,1,2, 2,1,1,2 } },
		new int[,] { {0,0,0,2, 0,0,2,0, 0,2,2,0, 0,1,0,0}, {1,2,1,2, 2,1,2,1, 1,2,2,1, 2,1,1,2 } },
		new int[,] { {0,0,2,0, 1,1,0,0, 1,0,0,0, 0,0,0,0}, {2,1,2,1, 1,1,2,2, 1,2,1,2, 2,2,1,1 } },
		new int[,] { {0,2,1,0, 2,0,0,0, 0,2,0,0, 0,0,1,0}, {1,2,1,2, 2,1,2,1, 1,2,2,1, 2,1,1,2 } },


		//add more fake games

	};


//    int newNumber(int last, int range)
//    {
//        int new_r = Random.Range(1, range);
//        if (last != new_r)
//        {
//            return new_r;
//        }
//        else
//        {
//            return newNumber(last, range);
//        }
//    }

	
	public ohhiSquare[] newGrid(ohhiSquare[] grid) {
		int gameIndex = Random.Range (0,ohhiGames.Length); //Get a random but valid gameIndex
		int i = 0;
		foreach (var square in grid) {
			square.isCorrect = false;
			square.state = ohhiGames[gameIndex][0,i];
			if (square.state == 0) {
				square.Playable = true;
			} else {
				square.Playable = false;
			}
			square.correctState = ohhiGames[gameIndex][1,i];
			i++;
		}

		return grid;
	}
    void cleanBoard(ohhiSquare[] sqaures)
    {
        foreach (var square in sqaures)
        {

            square.Playable = true;
            square.state = 0;
            square.count = ++counter;
        }
    }

//    bool checkBoard(ohhiSquare[] grid)
//    {
//        int blues = 0, reds = 0;
//        for (int i = 0; i < 4; i++)
//        {
//            for (int j = 0; j <= 12; j += 4)
//            {
//                if (grid[i + j].state == 1)
//                {
//                    reds++;
//                }
//                if (grid[i + j].state == 2)
//                {
//                    blues++;
//                }
//            }
//        }
//        int counter = 0;
//        
//        foreach(var square in grid)
//        {
//            if (square.state == 0)
//            {
//                counter++;
//            }
//            if(counter > 11)
//            {
//                return false;
//            }
//        }
//
//        if (reds > 2 || blues > 2)
//        {
//            return false;
//        }
//        else
//        {
//            return true;
//        }
//    }
//
//    public ohhiSquare[] newGrid(ohhiSquare[] grid)
//    {
//
//        int previous_r = 0;
//        previous_r_2 = 0;
//
//        cleanBoard(grid);
//
//
//        counter = 1;
//        foreach (var square in grid)
//        {
//            square.count = counter++;
//            int r = newNumber(previous_r_2, 3);
//            int p = Random.Range(0, 2);
//
//            if (1 > p)
//            {
//            square.state = r;
//            square.Playable = false;
//            previous_r_2 = previous_r;
//            previous_r = r;
//            }
//        }
//
//        if (checkBoard(grid))
//        {
//            return grid;
//        }
//        else
//        {
//            return newGrid(grid);
//        }
//    }
//
//    bool fullBoard(ohhiSquare[] grid)
//    {
//        bool full = false;
//        foreach (var square in grid)
//        {
//            if (square.state != 0)
//            {
//                full = true;
//            }
//            else
//            {
//                full = false;
//            }
//        }
//
//        return full;
//    }
//


    // Use this for initialization
    void Start()
    {
        smooth = 4f;
        highlightedSquare = 1;
        isCompleteAndCorrect = false;
        ohhiSquares = GetComponentsInChildren<ohhiSquare>();
        changeColorNow = false;
        next = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           ohhiSquares = newGrid(ohhiSquares);
        }
		CheckCompleteAndCorrect();
    }

    //Resets all playable squares to initial blank state
    public void Reset()
    {
        foreach (var square in ohhiSquares)
        {
            if (square.Playable)
            {
                square.state = 0;
            }
        }
    }

    public void shift(bool visible)
    {
        float smooth = 5f;
        if (visible)
        {
            next = showPos;
        }
        else
        {
            next = hidePos;
        }

        transform.position = Vector3.Lerp(transform.position, next, smooth * Time.deltaTime);	
    }

	public void CheckCompleteAndCorrect() {
		isCompleteAndCorrect = true;
		foreach (var square in ohhiSquares)
		{
			if (!square.isCorrect)
			{
				isCompleteAndCorrect = false;
			}
		}
	}


    public IEnumerator show()
    {
        while (Vector3.Distance(transform.position, showPos) > 0.005f)
        {
            transform.position = Vector3.Lerp(transform.position, showPos, Time.deltaTime * smooth);
            yield return null;
        }
    }

    public IEnumerator hide()
    {
        while (Vector3.Distance(transform.position, hidePos) > 0.005f)
        {
            transform.position = Vector3.Lerp(transform.position, hidePos, Time.deltaTime * smooth);
            yield return null;
        }
    }
}
