using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
	public int AllPoints;

	public float timeWastePoints = 2;

	public void ResetAll()
	{
		AllPoints = 0;
		Debug.Log ("reset pts");
	}
}

