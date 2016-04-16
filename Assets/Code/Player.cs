using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// Class that represents the player in game.
/// </summary>
public class Player : MonoBehaviour 
{
	[Serializable]
	public enum State
	{
		Fish,
		Bird,
		Jaguar,
	}

	public State _currentState = State.Jaguar;
	public Rigidbody2D _rigidBody = null;
	public float _velocity = 1f;
	public float _angularVelocity = 1f;


	public void FixedUpdate()
	{
		switch (this._currentState) {
			case State.Bird:
				this.UpdateBird ();
				break;
			case State.Fish:
				this.UpdateFish ();
				break;
			case State.Jaguar:
				this.UpdateJaguar ();
				break;
			default:
				break;
		}
	}

	public void UpdateBird()
	{
		
	}

	public void UpdateFish()
	{
	}

	public void UpdateJaguar()
	{
	}
}
