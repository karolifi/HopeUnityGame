using UnityEngine;
using System.Collections;

public class CameraOnPlayer : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	private float halfWidth;
	private Vector3 temp;

	void Start ()
	{
		halfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;

		offset = transform.position - player.transform.position; //following player
	}

	void LateUpdate ()
	{
		temp = player.transform.position + offset; //following player
		if (temp.y < -154f + halfWidth) {
			temp.y = -154f + halfWidth;
		}
		transform.position = temp;
	}
}
