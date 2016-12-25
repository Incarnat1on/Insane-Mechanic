using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {

	[SerializeField]
	List <LevelData> _levelData = new List<LevelData>();
	public LevelData GetInfoLevel(int lvl)
	{
		return _levelData[lvl];
	}
}
