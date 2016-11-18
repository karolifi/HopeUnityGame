using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;
	GameObject[] finishObjects;
	GameObject[] winObjects;

	private bool hasEnded;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
		winObjects = GameObject.FindGameObjectsWithTag("ShowOnWin");
		hidePaused();
		hideFinished();
		hideWin ();
		hasEnded = false;
	}

	// Update is called once per frame
	void Update () {

		//uses the space button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
		//shows finish gameobjects if player is dead and timescale = 0
		if (Time.timeScale == 0 && PlayerController.alive == false){
			showFinished();
		}

		if ((PlayerController.hasWon == true) && (hasEnded == false)) {
			Debug.Log ("WinRegistred");
			showWin ();
		}
			
	}
		
	//Reloads the Level
	public void Reload(){
		SceneManager.LoadScene("Main");
	}

	//loads inputted level
	public void LoadLevel(string level){
		SceneManager.LoadScene(level);
	}

	//controls the pausing of the scene
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		} else if (Time.timeScale == 0){
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

	//shows objects with ShowOnFinish tag
	public void showFinished(){
		foreach(GameObject g in finishObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnFinish tag
	public void hideFinished(){
		foreach(GameObject g in finishObjects){
			g.SetActive(false);
		}
	}

	public void hideWin(){
		foreach(GameObject g in winObjects){
			g.SetActive(false);
		}
	}
		
	public void showWin(){
		Debug.Log ("Won");
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		Invoke ("EndIt", fadeTime);

	}

	public void EndIt(){
		hasEnded = true;
		SceneManager.LoadScene ("EndScene");
		GameObject.Find ("Fader2").GetComponent<Fading> ().BeginFade (-1);
		Debug.Log ("Ended");
	}

}
