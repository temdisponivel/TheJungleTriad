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
		GameManager._instance = this;
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