using UnityEngine;
using System.Collections;

public class ModeDisplay : MonoBehaviour {

    public Controller controller;
    public TextMesh textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    void Update()
    {
        textMesh.text = controller.mode;
    }
}
