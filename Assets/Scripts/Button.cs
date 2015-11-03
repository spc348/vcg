using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public int ID;
	public VCController vcController;
	public bool highlighted;


	// Use this for initialization
	void Start () {
		vcController = GetComponentInParent<VCController>();
	}
	
	// Update is called once per frame
	void Update () {
		checkHighlight();
	}

	void checkHighlight()
	{
		if (ID == vcController.highlightedButton)
		{
			highlighted = true;
			gameObject.transform.localScale = new Vector3(5f, 1.2f, 1f);
			//textMesh.fontSize = onSize;
		}
		else
		{
			highlighted = false;
			gameObject.transform.localScale = new Vector3(4f, 1f, 1f);
			//textMesh.fontSize = offSize;
		}
	}
}
