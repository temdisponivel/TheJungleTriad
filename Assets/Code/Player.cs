﻿using System;
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
		Fish = 0,
		Bird = 1,
		Jaguar = 2,
	}

	static public Player Instance { get { return Player._instance; } }
	static protected Player _instance = null;

	public State _currentState = State.Fish;
	public Rigidbody2D _rigidBody = null;
	public Animator _animator = null;
	public float _velocity = 5f;
	public float _angularVelocity = 1f;
	public float _jumpForce = 1f;

	protected State _lastState = State.Fish;

	public void Start()
	{
		Player._instance = this;
		this._lastState = this._currentState;
	}

	public void FixedUpdate()
	{
		Vector2 force = ((Vector2)Vector2.right * this._velocity);
		force.x -= this._rigidBody.velocity.x;
		this._rigidBody.AddForce (force, ForceMode2D.Impulse);
		this._animator.SetInteger ("State", (int) this._currentState);
		if (this._lastState != this._currentState) {
			this.transform.rotation = Quaternion.identity;
		}
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
		this._rigidBody.gravityScale = 1;
		if (Input.GetAxis ("Vertical") > 0) {
			if (Vector2.Dot(this.transform.right, Vector2.one) < 1.10f) {
				this.transform.Rotate (Vector3.forward, this._angularVelocity * Input.GetAxis("Vertical"));
			}

			Vector2 force = ((Vector2)Vector2.one * (this._velocity / 1.5f));
			force -= this._rigidBody.velocity;
			this._rigidBody.AddForce (force, ForceMode2D.Impulse);
		}
		else if (Vector2.Dot(this.transform.right, Vector2.right) > .5f) {
			Debug.Log (Vector2.Dot (this.transform.right, Vector2.one));
			if (Vector2.Dot (this.transform.right, Vector2.one) > 0.8) {
				this.transform.Rotate (Vector3.forward, -this._angularVelocity);
				this._rigidBody.AddForce (-Vector2.up, ForceMode2D.Impulse);
			}
		}
	}

	public void UpdateFish()
	{
		this._rigidBody.gravityScale = 0;
		if (Input.GetAxis ("Vertical") != 0) {
			Vector2 force = ((Vector2)Vector2.up * this._velocity * 2); 	 	 
			force -= this._rigidBody.velocity;
			this._rigidBody.AddForce (force * Input.GetAxis("Vertical"), ForceMode2D.Force);
		}
	}

	public void UpdateJaguar()
	{
		this._rigidBody.gravityScale = 1;
		if (Input.GetButtonDown ("Jump") && this._rigidBody.velocity.y == 0) {
			this._rigidBody.AddForce (Vector2.up * this._jumpForce, ForceMode2D.Impulse);
		} else {
			this._rigidBody.AddForce (-Vector2.up * 2, ForceMode2D.Impulse);
		}
	}
}
