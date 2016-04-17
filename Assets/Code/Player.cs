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
		Fish = 0,
		Bird = 1,
		Jaguar = 2,
	}

	static public Player Instance { get { return Player._instance; } }
	static protected Player _instance = null;

	public State _currentState = State.Fish;
	public Rigidbody2D _rigidBody = null;
	public Animator _animator = null;
	public float _velocity = 1f;
	public float _angularVelocity = 1f;
	public float _jumpForce = 1f;

	public void Start()
	{
		Player._instance = this;
	}

	public void FixedUpdate()
	{
		Vector2 force = ((Vector2)Vector2.right * this._velocity);
		force.x -= this._rigidBody.velocity.x;
		this._rigidBody.AddForce (force, ForceMode2D.Impulse);
		this._animator.SetInteger ("State", (int) this._currentState);
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
		if (Input.GetAxis ("Vertical") > 0 && Vector2.Dot(this.transform.right, Vector2.one) < 1.40f) {
			this.transform.Rotate (Vector3.forward, this._angularVelocity * Input.GetAxis("Vertical"));
			Vector2 force = ((Vector2)Vector2.one * this._velocity);
			force -= this._rigidBody.velocity;
			this._rigidBody.AddForce (force, ForceMode2D.Impulse);
		}
		else if (Vector2.Dot(this.transform.right, Vector2.right) > .5f) {
			this.transform.Rotate (Vector3.forward, -this._angularVelocity);
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
		if (Input.GetButtonDown("Jump") && this._rigidBody.velocity.y >= 0)
		{
			this._rigidBody.AddForce (Vector2.up * this._jumpForce, ForceMode2D.Impulse);
		}
	}
}
