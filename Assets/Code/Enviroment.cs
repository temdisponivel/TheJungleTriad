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
	public int _minBarrierCount = 1;
	public int _maxBarrierCount = 10;
	public Vector2 _startPositionToPlaceBarrier;
	public Vector2 _endPositionToPlaceBarrier;
	public float _minDistanceBetweenBarrier = 1f;
	public float _maxDistanceBetweenBarrier = 1f;

	[Header("Food")]
	public GameObject _food = null;
	public Vector2 _startPositionToPlaceFood;
	public Vector2 _endPositionToPlaceFood;
	public int _maxCountInRow = 10f;

	public Vector2 StartOfEnviroment {get { return this.transform.TransformVector (this._startOfEnviromentObj.transform.position); } }
	public Vector2 EndOfEnviroment {get { return this.transform.TransformVector (this._endOfEnviromentObj.transform.position); } }

	public void Start()
	{
		float barrierCount = Random.Range (this._minBarrierCount, this._maxBarrierCount);
		float size = Vector2.Distance (this.StartOfEnviroment - this._startPositionToPlaceBarrier, this.EndOfEnviroment - this._endPositionToPlaceBarrier);
		float maxPossibleBarrier = (int)(size / this._minDistanceBetweenBarrier);
		barrierCount = Mathf.Clamp (barrierCount, 0, maxPossibleBarrier);
		for (int i = 0; i < barrierCount; i++) {
			
		}			
	}

	public void Update()
	{
		if (this.EndOfEnviroment.x < 
			Camera.current.transform.position.x - (Camera.current.orthographicSize * Camera.current.aspect)) {
			EnviromentBuilder.Instance.BuildNext ();
			GameObject.Destroy(this.gameObject);
		}
	}

	public void MoveStartTo(Vector2 position)
	{
		this.transform.position = (Vector2) this.StartOfEnviroment + position;
	}
}