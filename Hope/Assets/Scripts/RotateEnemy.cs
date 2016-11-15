using UnityEngine;
using System.Collections;

public class RotateEnemy : MonoBehaviour {

	public int degrees;

	// Update is called once per frame
	void Update () 
	{
		//Rotate thet transform of the game object this is attached to by 45 degrees, taking into account the time elapsed since last frame.
		transform.Rotate (new Vector3 (0, 0, degrees) * Time.deltaTime);
	}
}
