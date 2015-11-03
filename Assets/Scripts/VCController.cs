using UnityEngine;
using System.Collections;

public class VCController : MonoBehaviour
{
    public int highlightedButton;
    public Controller masterController;
    public Sudoku_Gameboard sudokuGameboard;
    public string action;
    public Vector3 showPos;
    public Vector3 hidePos;
    public float smooth;

    // Use this for initialization
    void Start()
    {
        smooth = 4f;
        highlightedButton = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (highlightedButton > 3)
        {
            highlightedButton = 0;
        }

        if (highlightedButton < 0)
        {
            highlightedButton = 3;
        }

        switch (highlightedButton)
        {
            case 0:
                action = "commit";
                break;
            case 1:
                action = "push";
                break;
            case 2:
                action = "pull";
                break;
            case 3:
                action = "update";
                break;
     
        }
    }

    public void Execute()
    {
        print("Executing " + action);
        if (action == "push")
        {
            sudokuGameboard.Push();
            sudokuGameboard.foldBoard = true;
        }
        if (action == "pull")
        {
            sudokuGameboard.Pull();
            sudokuGameboard.foldBoard = false;
        }
        if (action == "update")
        {
            sudokuGameboard.UpdateLocalCode();
        }
        if (action == "commit")
        {
            sudokuGameboard.Commit();
        }

    }

    public IEnumerator show()
    {
        Debug.Log("showing vc");
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
