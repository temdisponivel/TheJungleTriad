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

	static public Player Instance { get { return Player._instance; } }
	static protected Player _instance = null;

	public State _currentState = State.Fish;
	public Rigidbody2D _rigidBody = null;
	public float _velocity = 1f;
	public float _angularVelocity = 1f;

	public void Start()
	{
		Player._instance = this;
	}

	public void FixedUpdate()
	{
		this._rigidBody.AddForce (this.transform.right * this._velocity, ForceMode2D.Impulse);
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
