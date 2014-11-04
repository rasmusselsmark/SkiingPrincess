using System;
using UnityEngine;

/*
 * Notes
 * 
 * Sound effects: http://www.bfxr.net/
 * Music: http://www.pacdv.com/sounds/free-music-13.html
 * 
 */

public static class Utils
{
	public static Vector2 ScreenToGameObjectCoordinates(Vector3 screenPos)
	{
		Ray ray = Camera.main.ScreenPointToRay(screenPos);
		return ray.origin;
	}

	public static Vector2 GetScreenSize()
	{
		return ScreenToGameObjectCoordinates(new Vector2(Screen.width, Screen.height));
	}
}