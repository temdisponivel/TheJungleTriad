﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Class that holds usefull information for building a enviroment.
/// </summary>
public class Enviroment : MonoBehaviour
{
	public Player.State _targetState = Player.State.Bird;

	[Header("Enviroment localization")]
	public GameObject _startOfEnviromentObj = null;
	public GameObject _endOfEnviromentObj = null;

	[Header("Barriers")]
	public GameObject _barrier = null;
	public GameObject[] _barriersPosition = null;
	public int _minBarrierCount = 1;

	public Vector2 StartOfEnviroment {get { return this.transform.position + this._startOfEnviromentObj.transform.position; } }
	public Vector2 EndOfEnviroment {get { return this.transform.position + this._endOfEnviromentObj.transform.position; } }

	public void Start()
	{
		float barrierCount = Random.Range (this._minBarrierCount, this._barriersPosition.Length);
		for (int i = 0; i < barrierCount; i++) {
			int index = (int) Random.Range (0, this._barriersPosition.Length);
			GameObject b = (GameObject)GameObject.Instantiate (this._barrier, this._barriersPosition [index].transform.position, 
				this._barriersPosition [index].transform.rotation);
			b.transform.parent = this.transform;
		}
	}

	public void Update()
	{
		if (GameManager.Instance.CurrentCamera.WorldToViewportPoint(this._endOfEnviromentObj.transform.position).x < 0) {
			EnviromentBuilder.Instance.BuildNext ();
			GameObject.Destroy(this.gameObject);
		}
	}

	public Vector2 MoveStartTo(Vector2 position)
	{
		this.transform.position = new Vector2() { x = (position.x + this._endOfEnviromentObj.transform.localPosition.x), y = 0 };
		return position + (Vector2)this._endOfEnviromentObj.transform.localPosition;
	}
}