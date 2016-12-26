using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTheButtoN : Singleton <PushTheButtoN>  {
	float Timer;
	bool state;

	float points;
	[SerializeField]
	UIPanel loadingScreen;
	[SerializeField]
	UIProgressBar BAR;
	[SerializeField]
	InventoryContainer Inventory;

	public ItemSettings itemSettings {
		get { return _itemSettings; }
	}

	[SerializeField]
	ItemSettings _itemSettings;

	[SerializeField]
	LevelInfo levelInfo;

	[Header("         Info Labels          ")]
	[SerializeField]
	UILabel _timerLabel;
	[SerializeField]
	UILabel _levelPoints;
	[SerializeField]
	UILabel _allPoints;


	[Header("        End Game Widget         ")]
	[SerializeField]
	UIWidget endLevelWindow;
	[SerializeField]
	UILabel __allpoints;
	[SerializeField]
	UILabel __time;
	[SerializeField]
	UILabel __levelpoints;

	PlayerData _playerData;

	LevelController levelController;

	bool playing;

	public void InitLevel (LevelController _levelController)
	{
		levelController = _levelController;
		Debug.Log ("Level Initialize");
	}


	IEnumerator StartTimer ()
	{
	
		points = levelInfo.GetInfoLevel (Application.loadedLevel).points;
		_allPoints.text = _playerData.AllPoints.ToString();
		while (true) {
			yield return new WaitWhile (() => !state);
			//_timerLabel.color = new Color32 ((byte)Random.Range (0, 255), (byte)Random.Range (0, 255), (byte) Random.Range (0, 255), 255);
			_timerLabel.text = string.Format ("Время: {0}", (int)Timer);
			points -= Time.deltaTime * _playerData.timeWastePoints;
			_levelPoints.text = ((int)points).ToString();
			Timer += Time.deltaTime;
			yield return null;
		}

	}

	void Awake()
	{
		_timerLabel.enabled = false;
		endLevelWindow.alpha = 0;
		//create new class for player Data
		_playerData = new PlayerData ();
		_allPoints.text = _playerData.AllPoints.ToString();
		StartCoroutine (InitializeMain (1));
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			LevelComplete ();
		}

	}

	IEnumerator InitializeMain(int level){
		loadingScreen.alpha = 1;
		var p = Application.LoadLevelAsync (level);
		while (!p.isDone)
		{
			yield return null;
		}
		var timme = 2f;
		while (timme > 0)
		{
			timme -= Time.deltaTime;
			BAR.value = 1 - timme/2;
			yield return null;
		}

		_timerLabel.enabled = true;
		StartCoroutine (StartTimer ());
		state = true;
		Inventory.AddItems (levelInfo.GetInfoLevel (Application.loadedLevel)._Items);
		loadingScreen.alpha = 0;
	}

	public void StartLevel()
	{
		playing = !playing;
		levelController.StateLevel (playing);
	
	}

	public void LevelComplete ()
	{
		_playerData.AllPoints += (int)points;
		
		StopAllCoroutines ();
		//open stat window
		OpenEndWindow();
		//load next level
		Debug.Log("Load next level");

	}

	void OpenEndWindow ()
	{
		__allpoints.text = _allPoints.text;
		__time.text = _timerLabel.text;
		__levelpoints.text =((int) points).ToString();
		endLevelWindow.alpha = 1;
	}

	public void LoadNextLevel()
	{
		endLevelWindow.alpha = 0;

		StartCoroutine (InitializeMain (Application.loadedLevel + 1));
	}
}
