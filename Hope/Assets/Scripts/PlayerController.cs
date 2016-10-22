using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private int count;

	public float originalRange;
	public Light lt;

    void Start () 
	{
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;

		lt = GetComponent<Light>();
		originalRange = lt.range;
    }

	void FixedUpdate () 
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //Vector2 movement = new Vector2(moveHorizontal, 0.0f); //no vertical movement

        rb2d.AddForce(movement * speed);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			other.gameObject.SetActive (false); //removes the object that was picked up

			lt.range = originalRange + 0.5F;
			originalRange += 0.5F;
		}

		if (other.gameObject.CompareTag ("Goal")) 
		{
			lt.range = originalRange + 10;
			originalRange += 10;
		}
    }

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.CompareTag ("Enemy")) 
		{
			lt.range = originalRange - 0.5F;
			originalRange -= 0.5F;
		}
	}
}
