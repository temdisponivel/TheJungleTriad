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
	public int _minFoodCount = 1;
	public int _maxFoodCount = 10;
	public int _countInRow = 10;

	public Vector2 StartOfEnviroment {get { return this.transform.TransformVector (this._startOfEnviromentObj.transform.position); } }
	public Vector2 EndOfEnviroment {get { return this.transform.TransformVector (this._endOfEnviromentObj.transform.position); } }

	public void Start()
	{
		float barrierCount = Random.Range (this._minBarrierCount, this._maxBarrierCount);
		float size = Vector2.Distance (this.StartOfEnviroment - this._startPositionToPlaceBarrier, this.EndOfEnviroment - this._endPositionToPlaceBarrier);
		float maxPossibleBarrier = (int)(size / this._minDistanceBetweenBarrier);
		barrierCount = Mathf.Clamp (barrierCount, 0, maxPossibleBarrier);
		float averageDistance = size / barrierCount;
		Vector2[] barriesPosition = new Vector2[(int)barrierCount];
		Vector2 lastPositionBarrier = this.StartOfEnviroment + this._startPositionToPlaceBarrier;
		for (int i = 0; i < barrierCount; i++) {
			float distanceToLast = Random.Range (this._minDistanceBetweenBarrier, averageDistance);
			Vector2 position = lastPositionBarrier;
			position.x += distanceToLast;
			position.y += this.transform.position.y - Random.Range (-3, 3);
			GameObject.Instantiate (this._barrier, position, Quaternion.identity);
			barriesPosition [i] = position;
		}

		float foodCount = Random.Range (this._minFoodCount, this._maxFoodCount);
		int sequenceCount = (int)foodCount % this._countInRow;
		for (int i = 0; i < sequenceCount; i++)
		{
			for (int j = 0; j < foodCount / sequenceCount; j++) {
				
			}
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