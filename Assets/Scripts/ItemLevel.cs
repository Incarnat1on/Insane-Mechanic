using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemLevel
{
	public int id = 1;
	[SerializeField]
	public GameObject item;
	[SerializeField]
	public int count = 1;
	[SerializeField]
	public Sprite Icon;

}


