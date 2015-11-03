using System.Collections;
using UnityEngine;

public class MoveGameBoard : MonoBehaviour
{
    Vector3 NextPosition;
    Vector3 OffCamera;
    Vector3 OnCamera;

    float smooth;

    void Awake()
    {
        NextPosition = transform.position;
    }

    void MoveSudoku()
    {
        smooth = 5f;
        OffCamera = new Vector3(-1, 7, 0);
        OnCamera = new Vector3(-1, 2.25f, 0);

        if (Input.GetKeyDown(KeyCode.A))
        {
            NextPosition = OffCamera;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            NextPosition = OnCamera;
        }

        transform.position = Vector3.Lerp(transform.position, NextPosition, smooth * Time.deltaTime);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveSudoku();
    }
}
