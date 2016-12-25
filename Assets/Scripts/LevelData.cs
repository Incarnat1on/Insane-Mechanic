using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelData
{
	public int points;

	[Header("Items")]
	[SerializeField]
	public List <ItemLevel> _Items = new List<ItemLevel>(); 

}

