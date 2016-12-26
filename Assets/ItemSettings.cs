using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSettings : MonoBehaviour {

	[SerializeField]
	UIWidget widget;
	[SerializeField]
	UI2DSprite OnState;
	Transform _transform;
	[SerializeField]
	Sprite ForTransform;
	[SerializeField]
	Sprite ForRotation;
	[SerializeField]
	Sprite ForConnect;


	bool moving;
	bool rotating;
	ItemCall itemCalled;
	int countClicks;

	void Awake ()
	{
		widget.alpha = 0;
	}

	public void StartEvent (bool rotate = true)
	{
		if (rotate)
			StartRotate ();
		else
			Connect ();
	}

	public void SetItem (Transform transform, ItemCall _itemCalled)
	{
		if (itemCalled != null)
			itemCalled.active = false;
		itemCalled = _itemCalled;
		itemCalled.active = true;
		_transform = transform;
		OpenMenuItem ();
	}

	public void StartRotate()
	{
		if (!rotating) {
			rotating = true;
			moving = false;
			OnState.sprite2D = ForRotation;
			OnState.alpha = 0.5f;
			StartCoroutine (ChangeRotation ());
		}
		else 
		{
			moving = false;
			rotating = false;
		}
	}

	public void StartPosition()
	{
		if (!moving) {
			moving = true;
			rotating = false;
			OnState.sprite2D = ForTransform;
			OnState.alpha = 0.5f;
			StartCoroutine (ChangePosition ());
		}
		else 
		{
			moving = false;
			rotating = false;
		}
	}

	public void Connect ()
	{
		OnState.sprite2D = ForConnect;
		OnState.alpha = 0.5f;
	}

	public void End()
	{
		StopAllCoroutines ();
		moving = false;
		rotating = false;
		widget.alpha = 0;
		itemCalled.active = false;
	}

	void OpenMenuItem ()
	{
		OnState.alpha = 0;
		widget.alpha = 1;
		var temp = UICamera.mainCamera.ScreenToWorldPoint (Camera.main.WorldToScreenPoint (_transform.position));
		this.transform.position = temp;
		this.transform.localPosition = ClampVector (this.transform.localPosition);
	}

	IEnumerator ChangePosition ()
	{
		var t = _transform;
		OnState.transform.localEulerAngles = Vector3.zero;
		yield return new WaitForSeconds(0.1f);
		while (moving) {
			#if UNITY_EDITOR
			if (Input.GetMouseButton (0)) {
				t.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				t.position = new Vector3 (t.position.x, t.position.y, 0);
			}
			#else
			t.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			t.position = new Vector3 (t.position.x, t.position.y, 0);
			#endif
			var temp = UICamera.mainCamera.ScreenToWorldPoint (Camera.main.WorldToScreenPoint (t.position));
			this.transform.position = temp;
			this.transform.localPosition = ClampVector (this.transform.localPosition);
			yield return new WaitForEndOfFrame ();
		}
	}

	IEnumerator ChangeRotation ()
	{
		var t = _transform;
		var anim = OnState.transform;
		yield return new WaitForSeconds(0.1f);
		while (rotating ) {
			var euler = t.localEulerAngles;
			#if UNITY_EDITOR
			if (Input.GetMouseButton(0)){
				euler += new Vector3(euler.x,euler.y,Input.GetAxis ("Mouse Y")*5 - Input.GetAxis ("Mouse X")*5);
			}
			#else
			euler += new Vector3(euler.x,euler.y,Input.GetAxis ("Mouse Y")*5 - Input.GetAxis ("Mouse X")*5);
			#endif
			t.localEulerAngles = euler;
			anim.localEulerAngles += new Vector3(0,0,25*Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}
	}

	Vector3 ClampVector (Vector3 vector)
	{
		vector.x = Mathf.Clamp (vector.x, -300f, 145f);
		vector.y = Mathf.Clamp (vector.y, -75f, 200f);
		return vector;
	}
}
