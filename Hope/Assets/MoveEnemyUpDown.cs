using UnityEngine;
using System.Collections;

public class MoveEnemyUpDown : MonoBehaviour {

	public float moveLength;
	public Vector3 moveDirection;
	public float movementSpeed = 2;
	private Vector3 startPosition;

	void Start () {
		startPosition = GetComponent <Transform>().position;
		if (moveDirection.magnitude != 1) {
			moveDirection = moveDirection.normalized;
		}
	}


	// Update is called once per frame
	void Update () 
	{
		if (((startPosition.y - moveLength)< (transform.position.y)) && ((transform.position.y) < (startPosition.y + moveLength))) {
			moveObject ();
		}
		else {
			moveDirection = -moveDirection;
			moveObject ();
		}
	}

	void moveObject ()
	{
		transform.Translate (moveDirection * movementSpeed * Time.deltaTime);
	}
}
