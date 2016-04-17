using UnityEngine;
using System.Collections;

/// <summary>
/// Class for the food (or gold).
/// </summary>
public class Food : MonoBehaviour 
{
	public int _pointsGiven = 10;

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			GameManager.Instance.Score += this._pointsGiven;
			GameObject.Destroy (this.gameObject);
		}
	}
}
