using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	public void Update() {
		if (Input.anyKeyDown) {
			SceneManager.LoadScene ("BuilderScene");
		}
	}
}
