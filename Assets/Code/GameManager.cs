using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	static protected GameManager _instance = null;
	static public GameManager Instance { get { return GameManager._instance; } }

	public int Score { get; set; }

	public void Start()
	{
		if (GameManager.Instance == null) {
			GameManager._instance = this;
			GameObject.DontDestroyOnLoad (this.gameObject);
		} else {
			GameObject.Destroy (this.gameObject);
			return;
		}
	}

	public void GameOver()
	{
		
	}
}