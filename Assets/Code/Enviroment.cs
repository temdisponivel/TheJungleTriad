using UnityEngine;
using System.Collections;

/// <summary>
/// Class that holds usefull information for building a enviroment.
/// </summary>
public class Enviroment : MonoBehaviour
{
	[Header("Enviroment localization")]
	public GameObject _startOfEnviromentObj = null;
	public GameObject _endOfEnviromentObj = null;

	[Header("Barriers")]
	public GameObject _barrier = null;
	public GameObject[] _barriersPosition = null;
	public int _minBarrierCount = 1;

	public Vector2 StartOfEnviroment {get { return this.transform.TransformVector (this._startOfEnviromentObj.transform.position); } }
	public Vector2 EndOfEnviroment {get { return this.transform.TransformVector (this._endOfEnviromentObj.transform.position); } }

	public void Start()
	{
		float barrierCount = Random.Range (this._minBarrierCount, this._barriersPosition.Length);
		for (int i = 0; i < barrierCount; i++) {
			int index = (int) Random.Range (0, this._barriersPosition.Length);
			GameObject.Instantiate (this._barrier, this._barriersPosition [index].transform.position, this._barriersPosition [index].transform.rotation);
		}
	}

	public void Update()
	{
		if (!this.GetComponent<SpriteRenderer>().isVisible && this.EndOfEnviroment.x < Camera.current.transform.position.x) {
			EnviromentBuilder.Instance.BuildNext ();
			GameObject.Destroy(this.gameObject);
		}
	}

	public void MoveStartTo(Vector2 position)
	{
		Debug.Log ("ALOOOO");
		this.transform.position = (Vector2) this.StartOfEnviroment + position;
	}
}