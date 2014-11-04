using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(150, 260, 100, 50), "Start"))
		{
			Application.LoadLevel("Skiing");
		}
	}
}
