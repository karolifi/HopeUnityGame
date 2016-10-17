using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private int count;

    void Start () 
	{
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
    }

	void FixedUpdate () 
	{
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //Vector2 movement = new Vector2(moveHorizontal, 0.0f); //no vertical movement

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive (false);

			//Add one to the current value of our count variable.
			//could be a change in the light value?
			count = count + 1;
		}
		//if enemy, then execute... some change in the light
    }
}
