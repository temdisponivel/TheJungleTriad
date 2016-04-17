using UnityEngine;
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

	public void MoveStartTo(Vector2 position)
	{
		this.transform.position = new Vector2() { x = ((Vector2)this._startOfEnviromentObj.transform.localPosition - position).x, y = 0 };
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			if (Player.Instance._currentState != this._targetState) {
				GameManager.Instance.GameOver ();
			}
		}
	}
}