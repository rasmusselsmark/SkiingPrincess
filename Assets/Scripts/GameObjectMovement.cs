using UnityEngine;
using System.Collections;

public class GameObjectMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(0, GameController.Speed, 0);

		if (transform.position.y > 6)
		{
			Destroy(transform.gameObject);
		}
	}
}
