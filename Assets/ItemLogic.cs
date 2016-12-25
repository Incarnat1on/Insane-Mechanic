using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour
{
	[SerializeField]
	UI2DSprite _sprite;


	[SerializeField]
	UILabel count;
	int _count;

	bool use;

	public void PrepareItem(ItemLevel _it)
	{
		_sprite.sprite2D = _it.Icon;
		_count = _it.count;
		UpdateItem ();
	}

	public void Use()
	{
		_count -= 1;
		count.text = _count.ToString();
		if (_count <= 0) {
			//hide item
		}
		else 
		{
			StartCoroutine (MoveItem ());
			UpdateItem ();
		}
	}

	void UpdateItem ()
	{
		count.text = _count.ToString ();
	}

	IEnumerator MoveItem ()
	{
		while (use) {
			yield return new WaitForFixedUpdate();
		}
		throw new System.NotImplementedException ();
	}
}

