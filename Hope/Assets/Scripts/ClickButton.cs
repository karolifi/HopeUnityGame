using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour {

	public void startClick(){
		SceneManager.LoadSceneAsync ("Main");
	}
}
