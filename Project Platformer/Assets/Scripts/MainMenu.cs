﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	public string seeControls;
	public int playerLives;
	public int playerHealth;
	public string level1Tag;

	public void NewGame() {
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);

		PlayerPrefs.SetInt (level1Tag, 1);
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect() {
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);

		PlayerPrefs.SetInt (level1Tag, 1);
		Application.LoadLevel (levelSelect);
	}

	public void SeeControls() {
		Application.LoadLevel (seeControls);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
