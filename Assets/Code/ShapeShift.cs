using UnityEngine;
using System.Collections;

/// <summary>
/// Class responsible for making the shift from one shape to another
/// </summary>
public class ShapeShift : MonoBehaviour 
{
	public string _keyToPress = "1";
	public Player.State _shape = Player.State.Jaguar;

	public void OnTriggerStay2D(Collider2D coll)
	{
		if (Input.GetKeyDown (this._keyToPress) && Player.Instance._currentState != this._shape && coll.gameObject.tag == "Player") {
			Player.Instance._currentState = this._shape;
		} else if (Input.anyKey && !Input.GetKey (this._keyToPress)) {
			GameManager.Instance.GameOver ();
		}
	}
}
