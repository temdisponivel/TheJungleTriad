using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	static protected GameManager _instance = null;
	static public GameManager Instance { get { return GameManager._instance; } }

	public Camera CurrentCamera = null;
	public int Score { get; set; }

	public float _accelerationPerSecond = .1f;

	public void Start()
	{
		if (GameManager.Instance == null) {
			GameManager._instance = this;
			GameObject.DontDestroyOnLoad (this.gameObject);
		} else {
			GameObject.Destroy (this.gameObject);
			return;
		}
		this.StartCoroutine (this.Accelerate ());
	}

	public void GameOver()
	{
		SceneManager.LoadScene ("GameOver");
	}

	public IEnumerator Accelerate()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			if (Player.Instance != null) {
				Player.Instance._velocity += this._accelerationPerSecond;
			}
		}
	}
}