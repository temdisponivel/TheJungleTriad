using UnityEngine;
using System.Collections;

/// <summary>
/// Script that moves a objeto towards player.
/// </summary>
public class FollowCamera : MonoBehaviour 
{
	public Vector2 _offSet;

	public void Update()
	{
		Vector2 position = Vector2.MoveTowards (this.transform.position, (Vector2)Player.Instance.transform.position - this._offSet, 1);
		this.transform.position = new Vector3() { x = position.x, y = this.transform.position.y, z = this.transform.position.z };
	}
}
