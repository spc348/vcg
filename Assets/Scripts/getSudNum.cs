using UnityEngine;
using System.Collections;

public class getSudNum : MonoBehaviour {

	private Cell parentCell;
	private TextMesh textMesh;

	// Use this for initialization
	void Start () {
		parentCell = GetComponentInParent<Cell>();
		textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!parentCell.playable) {
			textMesh.text = parentCell.sudValue.ToString();
		} else {
			textMesh.text = "";
		}
	}
}
