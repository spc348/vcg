using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public AudioSource audSrc;
    public AudioClip vcRollover;
	public AudioClip vcSelect;
    public AudioClip sudRollover;
    public AudioClip sudSelect;
    public AudioClip handRollover;
    public AudioClip ohhiRollover;
    public AudioClip ohhiAppear;
    public AudioClip ohhiSwitch;
    public AudioClip ohhiComplete;

	public string yesSign;
	public string noSign;

    public Hand_Controller handController;
    public ohhiGameBoard ohhi;
    public Sudoku_Gameboard sudokuController;
    public VCController vcController;
    public string mode;
    int player;
    public string left, right, up, down, yes, no, modeCycle, modeVC, modeSudoku, modeOhhi, modeHand;

    // Use this for initialization
    void Start()
    {
        mode = "vc";
        audSrc = GetComponent<AudioSource>();
    }


    void VC_Movement()
    {

        if (Input.GetKeyDown(up))
        {
            vcController.highlightedButton--;
            PlaySFX(vcRollover);
        }

        if (Input.GetKeyDown(down))
        {
            vcController.highlightedButton++;
            PlaySFX(vcRollover);
        }

        if (Input.GetKeyDown(yes))
        {
			PlaySFX (vcSelect);
            vcController.Execute();
            //have a sudoku button 
        }


        if (Input.GetKeyDown(no))
        {
            StartCoroutine(vcController.hide());
            mode = "sudoku";
        }

    }
    void Ohhi_Movement()
    {
        if (ohhi.isCompleteAndCorrect)
        {
            sudokuController.placeNum = true;
            PlaySFX(ohhiComplete);
            StartCoroutine(ohhi.hide());
            mode = "sudoku";
        }

        if (Input.GetKeyDown(right))
        {
            print("ohhi right");
            if (ohhi.highlightedSquare < 16)
            {
                ohhi.highlightedSquare++;
                PlaySFX(ohhiRollover);
            }
        }

        if (Input.GetKeyDown(left))
        {
            if (ohhi.highlightedSquare > 1)
            {
                ohhi.highlightedSquare--;
                PlaySFX(ohhiRollover);
            }
        }

        if (Input.GetKeyDown(up))
        {
            if (ohhi.highlightedSquare - 4 >= 1)
            {
                ohhi.highlightedSquare -= 4;
                PlaySFX(ohhiRollover);
            }
        }

        if (Input.GetKeyDown(down))
        {
            if (ohhi.highlightedSquare + 4 <= 16)
            {
                ohhi.highlightedSquare += 4;
                PlaySFX(ohhiRollover);
            }
        }

        if (Input.GetKeyDown(yes))
        {
            PlaySFX(ohhiSwitch);
            ohhi.changeColorNow = true;
        }

        if (Input.GetKeyDown(no))
        {
            StartCoroutine(ohhi.hide());
            ohhi.Reset();
            StartCoroutine(handController.show());
            PlaySFX(ohhiAppear);
            mode = "hand";
        }
    }

    void Sudoku_Movement()
    {

        if (Input.GetKeyDown(right))
        {
            if (sudokuController.highlightedSquare < 81)
            {
                sudokuController.highlightedSquare++;
            }
            PlaySFX(sudRollover);
        }

        if (Input.GetKeyDown(left))
        {
            if (sudokuController.highlightedSquare > 1)
            {
                sudokuController.highlightedSquare--;
            }
            PlaySFX(sudRollover);
        }

        if (Input.GetKeyDown(up))
        {
            if (sudokuController.highlightedSquare - 9 >= 1)
            {
                sudokuController.highlightedSquare -= 9;
            }
            PlaySFX(sudRollover);
        }

        if (Input.GetKeyDown(down))
        {
            if (sudokuController.highlightedSquare + 9 <= 81)
            {
                sudokuController.highlightedSquare += 9;
            }
            PlaySFX(sudRollover);

        }

        if (Input.GetKeyDown(yes))
        {
            PlaySFX(sudSelect);
            StartCoroutine(handController.show());
            mode = "hand";
        }

        if (Input.GetKeyDown(no))
        {
            StartCoroutine(vcController.show());
            mode = "vc";
        }

    }

    void Hand_Movement()
    {
        if (Input.GetKeyDown(right))
        {
            if (handController.highlightedSquare < 5)
            {
                handController.highlightedSquare++;
            }
            PlaySFX(handRollover);
        }

        if (Input.GetKeyDown(left))
        {
            if (handController.highlightedSquare > 1)
            {
                handController.highlightedSquare--;
            }
            PlaySFX(handRollover);
        }
        if (Input.GetKeyDown(yes))
        {
            sudokuController.numToPlace = handController.numToPlace;
            StartCoroutine(handController.hide());
           	ohhi.newGrid(ohhi.ohhiSquares);
            StartCoroutine(ohhi.show());    
            mode = "ohhi";
        }

        if (Input.GetKeyDown(no))
        {
            StartCoroutine(handController.hide());
            mode = "sudoku";
        }
    }

    void Update()
    {
        manualModeSwitch();

        switch (mode)
        {
            case "vc":
				yesSign = "Select";
				noSign = "Sudoku";
                VC_Movement();
                break;
            case "sudoku":
				yesSign = "Select";
				noSign = "VC";
                Sudoku_Movement();
                break;
            case "ohhi":
				yesSign = "Select";
				noSign = "Hand";
                Ohhi_Movement();
                break;
            case "hand":
				yesSign = "Select";
				noSign = "Sudoku;";
                Hand_Movement();
                break;
            default:
                break;
        }
    }

    public void manualModeSwitch()
    {
        if (Input.GetKeyDown(modeVC))
        {
            mode = "vc";
        }
        else if (Input.GetKeyDown(modeSudoku))
        {
            mode = "sudoku";
        }
        else if (Input.GetKeyDown(modeOhhi))
        {
            mode = "ohhi";
        }
        else if (Input.GetKeyDown(modeHand))
        {
            mode = "hand";
        }
    }

    public void PlaySFX(AudioClip audioClip)
    {
        if (!audSrc.isPlaying)
        {
            audSrc.PlayOneShot(audioClip);
        }

    }
}