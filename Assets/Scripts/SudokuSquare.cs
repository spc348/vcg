using UnityEngine;
using System.Collections;

public class SudokuSquare : MonoBehaviour
{


    public bool highlighted;
	public bool playable;
	public bool foldBegan;
	public bool unfoldBegan;
	public bool isCorrect;
	public bool rollOverPlayed;
	private float journeyLength;
	private float startTime;
	public float speed = 1.0f;
	public float smooth;
	public int playerAnswer;
	public int correctNum, ID;
	public int row;
	public int col;
	private int offSize, onSize;
	public TextMesh textMesh;
	public string test;
	public Server server;
    public Sudoku_Gameboard boardcontroller;
	public AudioSource audSrc;

	public Vector3 travelPos = new Vector3(0f,0f,0f);
	public Vector3 boardPos; 

    void Awake()
    {
		boardPos = transform.position;
		smooth = 4f;
        correctNum = 6;
        highlighted = false;
	//	audSrc = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start()
    {
		//Fold stuff
		transform.position = travelPos;

		foldBegan = false;
		speed = 2f;
        textMesh = gameObject.GetComponent<TextMesh>();
		boardcontroller = GetComponentInParent<Sudoku_Gameboard>();
//		journeyLength = Vector3.Distance(boardPos, travelPos);

		//Font sizes
		offSize = textMesh.fontSize;
		onSize = offSize * 2;
		if(ID==1) {
			rollOverPlayed = true;
		}

    }

    public void changeValue()
    {
        if (highlighted && boardcontroller.placeNum)
        {
            playerAnswer = boardcontroller.numToPlace;
            boardcontroller.placeNum = false;
        }
    }

    void checkHighlight()
    {
        if (ID == boardcontroller.highlightedSquare)
        {
            highlighted = true;
            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            textMesh.fontSize = onSize;
        }
        else
        {
            highlighted = false;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            textMesh.fontSize = offSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
		InitBoardDisplay();
		checkHighlight();
        changeValue();


    }

	public void CheckCorrect() {
		if (playerAnswer == correctNum) {
			isCorrect = true;
		}
	}

	public void InitBoardDisplay() {

		if (playerAnswer==0) {
			textMesh.text = "";
		} else {
           // print("player answer changed");
			textMesh.text = playerAnswer.ToString();
		}
	
	}


		
		


	public IEnumerator fold() {
//		if (!foldBegan){
//			startTime = Time.time;
//			foldBegan = true;
//			unfoldBegan = false;
//		}
//		float distCovered = (Time.time - startTime) * speed;
//		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (transform.position,travelPos,Time.deltaTime*smooth);
		yield return null;
	}

	public IEnumerator unfold() {
//		if (!foldBegan){
//			startTime = Time.time;
//			unfoldBegan = true;
//			foldBegan = false;
//		}
//		float distCovered = (Time.time - startTime) * speed;
//		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (transform.position,boardPos,Time.deltaTime*smooth);
		yield return null;
	}
}
