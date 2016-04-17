using UnityEngine;
using System.Collections;

public class EnviromentBuilder : MonoBehaviour 
{
	public GameObject[] _possibleEnviroments = null;

	public Vector2 _endOfLastEnviroment;

	static public EnviromentBuilder Instance { get { return EnviromentBuilder._instance; } }
	static protected EnviromentBuilder _instance = null;

	public void Start()
	{
		EnviromentBuilder._instance = this;
	}

	public void BuildNext()
	{
		GameObject nextEnviroment = this._possibleEnviroments[Random.Range (0, this._possibleEnviroments.Length)];
		GameObject next = (GameObject) GameObject.Instantiate (nextEnviroment);
		Enviroment enviroment = next.GetComponent<Enviroment> ();
		this._endOfLastEnviroment = enviroment.MoveStartTo (this._endOfLastEnviroment);
		 //= enviroment._endOfEnviromentObj.transform.position;
	}
}
