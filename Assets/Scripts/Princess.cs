using UnityEngine;
using System.Collections;

public class Princess : MonoBehaviour
{
	public AudioClip scoreSound;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameController.Lives <= 0)
			return;

		Vector2 screen = Utils.GetScreenSize();

		transform.localEulerAngles = new Vector2(0, 0);

		// movement
		float moveHorizontal = 0;
		float moveVertical = GameController.Speed * Time.deltaTime * 10; // move a little upwards

		// horizontal
		if (Input.GetAxis("Mouse X") < 0) moveHorizontal = -Time.deltaTime * 5;
		if (Input.GetAxis("Mouse X") > 0) moveHorizontal = Time.deltaTime * 5;

		if ((moveHorizontal > 0) && (transform.position.x < screen.x))
		{
			transform.Translate (moveHorizontal, 0, 0);
			transform.localEulerAngles = new Vector3(0, 0, 7);
		}
		if ((moveHorizontal < 0) && (transform.position.x > -screen.x))
		{
			transform.Translate (moveHorizontal, 0, 0);
			transform.localEulerAngles = new Vector3(0, 0, -7);
		}

		// vertical
		if (Input.GetAxis("Mouse Y") < 0) moveVertical = -GameController.Speed * Time.deltaTime * 20;
		if (Input.GetAxis("Mouse Y") > 0) moveVertical = GameController.Speed * Time.deltaTime * 20;

		if ((moveVertical < 0) && (transform.position.y > -screen.y))
			transform.Translate (0, moveVertical, 0);
		
		if ((moveVertical > 0) && (transform.position.y < screen.y - 1))
			transform.Translate (0, moveVertical, 0);
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "Goldcoin")
		{
			if (scoreSound != null)
				audio.PlayOneShot(scoreSound);

			GameController.CollectedGoldCoin();
			Destroy(collider.gameObject);
		}

		if (collider.gameObject.tag == "Tree")
		{
			GameController.HitTree();
		}
	}

	public void OnGUI()
	{
		Vector2 screen = Utils.GetScreenSize();

		GUI.color = Color.black;
		GUI.Label(new Rect(10, 85, 250, 20), string.Format("Princess position: {0}", transform.position));
		GUI.Label(new Rect(10, 105, 250, 20), string.Format("Screen: {0},{1}", screen.x, screen.y));

		// Vector2 pos = Utils.ScreenToGameObjectCoordinates(Input.mousePosition);
		// GUI.Label(new Rect(10, 65, 250, 20), string.Format("Ray origin: {0}", pos));
	}
}
