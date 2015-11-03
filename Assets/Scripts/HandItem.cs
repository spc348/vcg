using UnityEngine;
using System.Collections;

public class HandItem : MonoBehaviour {

    public Hand_Controller handController;
    public int value;
    public int ID;
    public bool highlighted;



	void Start () {
        handController = gameObject.GetComponentInParent<Hand_Controller>();
	}

    public void CheckHighlight()
    {
        if (ID == handController.highlightedSquare)
        {
            highlighted = true;
            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        }
        else
        {
            highlighted = false;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        CheckHighlight();

        if (highlighted)
        {
            handController.numToPlace = value;
           // print(handController.numToPlace + " from handitem");
        }

	}
}
