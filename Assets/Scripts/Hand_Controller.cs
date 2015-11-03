using UnityEngine;
using System.Collections;

public class Hand_Controller : MonoBehaviour {

    public int highlightedSquare, numToPlace;
	public Vector3 hidePos;
	public Vector3 showPos;
	public float smooth;

	void Awake() {
		smooth = 4f;
	}

    void Start()
    {
		highlightedSquare = 1;

//		showPos = new Vector3 (-20.3f,-13.3f,0f);
    }

    void Update()
    {
    }


	public IEnumerator show() {
        Debug.Log("showing hand");
		while(Vector3.Distance(transform.position, showPos) > 0.005f){
			transform.position = Vector3.Lerp (transform.position,showPos,Time.deltaTime*smooth);
			yield return null;
		}
	}

	public IEnumerator hide() {
        Debug.Log("hiding hand");
		while(Vector3.Distance(transform.position, hidePos) > 0.005f){
			transform.position = Vector3.Lerp (transform.position,hidePos,Time.deltaTime*smooth);
			yield return null;
		}
	}



}
