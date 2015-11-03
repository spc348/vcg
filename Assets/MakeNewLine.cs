using UnityEngine;
using System.Collections;

public class MakeNewLine : MonoBehaviour {

    public DrawLine drawLine;
    public Vector3 next;

	// Use this for initialization
	void Start () {
	    
	}

    public void assignNewPoints()
    {
        drawLine.makeNewPoint(next);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            assignNewPoints();
        }
	
	}
}
