using UnityEngine;
using System.Collections;

/// <summary>
/// Script that moves a objeto towards player.
/// </summary>
public class FollowCamera : MonoBehaviour 
{
	public void Update()
	{
		this.transform.position = Vector2.MoveTowards (this.transform.position, Player.Instance.transform.position, 1);
	}
}
