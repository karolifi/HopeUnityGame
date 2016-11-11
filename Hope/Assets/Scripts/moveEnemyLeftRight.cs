using UnityEngine;
using System.Collections;

public class moveEnemyLeftRight : MonoBehaviour {

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
		if (((startPosition.x - moveLength)< (transform.position.x)) && ((transform.position.x) < (startPosition.x + moveLength))) {
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
