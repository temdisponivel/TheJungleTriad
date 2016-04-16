using UnityEngine;
using System.Collections;

/// <summary>
/// Class that represents a barrier that player cannot touch.
/// </summary>
public class Barrier : MonoBehaviour
{
	public BoxCollider2D _collider = null;

	public void Start()
	{
		this._collider = this.GetComponent<BoxCollider2D>();
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			GameManager.Instance.GameOver();
		}
	}
}
