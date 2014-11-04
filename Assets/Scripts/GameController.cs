using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	private const float InitialSpeed = 0.075f;

	public static int Score = 0;
	public static int Lives = 3;
	public static float Speed = InitialSpeed;

	public GameObject Tree;
	public GameObject GoldCoin;

	// Use this for initialization
	void Start ()
	{
		// NewGame();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Lives <= 0)
			return;

		Vector2 screen = Utils.GetScreenSize();

		// Gold coins
		if (Random.value > (1 - Speed * 0.3))
		{
			Vector2 position = new Vector2(Random.Range(-screen.x, screen.x), -4);
			Instantiate(GoldCoin, position, Quaternion.identity);
		}

		// Trees
		if (Random.value > (0.99f - Speed * 0.3))
		{
			Vector2 position = new Vector2(Random.Range(-screen.x, screen.x), -4);
			Instantiate(Tree, position, Quaternion.identity);
		}
	}

	public void OnGUI()
	{
		GUIStyle style = new GUIStyle
		{ 
			fontSize = 20
		};

		GUI.color = Color.black;
		GUI.Label(new Rect(10,5,80,20), string.Format("Lives: {0}", Lives), style);
		GUI.Label(new Rect(10,25,150,20), string.Format("Score: {0}", Score), style);

		if (Lives <= 0)
		{
			GUIStyle gameOverStyle = new GUIStyle
			{ 
				fontSize = 24
			};
			// GUI. = Color.red;
			GUI.Label(new Rect(50,100,80,20), "Game Over!", gameOverStyle);

			if (GUI.Button(new Rect(80, 140, 100, 50), "Restart"))
				NewGame();
		}
		// GUI.Label(new Rect(10, 105, 250, 20), string.Format("Screen size: {0}, {1}", Screen.width, Screen.height));
		// GUI.Label(new Rect(10, 125, 250, 20), string.Format("Screen size: {0}", Utils.GetScreenSize()));
	}

	public static void HitTree ()
	{
		Lives--;

		if (Lives <= 0)
		{
			// Game over
			Lives = 0;
			Speed = 0f;
			Camera.main.audio.Stop();
		}
		else
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public static void CollectedGoldCoin ()
	{
		Score++;
		Speed += 0.005f;
	}

	public static void NewGame()
	{
		Lives = 3;
		Score = 0;
		Speed = InitialSpeed;
		Application.LoadLevel(Application.loadedLevel);
	}
}
