using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

	public float originalRange;
	public Light lt;
	public static bool alive;
	public static bool hasWon;

    void Start () 
	{
        rb2d = GetComponent<Rigidbody2D>();
		alive = true;
		hasWon = false;

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
		
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play(); //plays the pickup sound from an audioSource component on the player object
			other.gameObject.SetActive (false); //removes the object that was picked up

			lt.range = originalRange + 0.5F;
			originalRange += 0.5F;
		}

		if (other.gameObject.CompareTag ("Goal")) 
		{
			lt.range = originalRange + 10;
			originalRange += 10;

			AudioSource goalSound = other.gameObject.GetComponent<AudioSource>();
			goalSound.Play();

			hasWon = true;
		}
    }

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.CompareTag ("Enemy")) 
		{
			//while contact point exists?
			lt.range = originalRange - 1.0F;
			originalRange -= 1.0F;
			AudioSource gravitySound = GameObject.FindGameObjectWithTag("AllEnemies").GetComponent<AudioSource>();
			gravitySound.Play ();
		}
		if (lt.range <=0)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			alive = false;
			Time.timeScale = 0;
		}
	}
}
