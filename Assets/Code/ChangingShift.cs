using UnityEngine;
using System.Collections;

public class ChangingShift : MonoBehaviour 
{
	public Player.State _targetState;

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			if (Player.Instance._currentState != this._targetState) {
				GameManager.Instance.GameOver ();
			}
		}
	}
}
