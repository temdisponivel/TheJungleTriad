using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Replay : MonoBehaviour 
{
	public void Restart()
	{
		SceneManager.LoadScene ("BuilderScene");
	}
}
