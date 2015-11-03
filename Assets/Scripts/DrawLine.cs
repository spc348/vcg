using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private float counter;
	private float distance;
    Transform nextDestination;
	public Transform origin;
	public Transform destination;
	public float lineDrawSpeed = 6f;
    bool changed;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetPosition(0, origin.position);
		lineRenderer.SetWidth(.45f, .45f);

		distance = Vector3.Distance(origin.position, destination.position);
	}

    public void makeNewPoint(Vector3 next)
    {
        nextDestination.position = next;
    }
	
	// Update is called once per frame
	void Update () {
		if (counter < distance) {
			counter += .1f / lineDrawSpeed;
			float x = Mathf.Lerp (0,distance,counter);
			Vector3 pointA = origin.position;
			Vector3 pointB = destination.position;

			//Get unit vector in the desired direction, 
			//multiply by the desired length and add the starting point.
			Vector3 pointAlongLine = x * Vector3.Normalize(pointB-pointA) + pointA;

			lineRenderer.SetPosition(1, pointAlongLine);
        }
        else
        {

            origin.position = destination.position;
        }

	
	}
}
