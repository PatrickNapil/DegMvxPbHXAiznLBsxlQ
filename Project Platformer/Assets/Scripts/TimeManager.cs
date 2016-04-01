using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;

	private Text timeText;

	private PausedMenu thePauseMenu;

	public GameObject gameOverScreen;

	public PlayerController player;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();

		thePauseMenu = FindObjectOfType<PausedMenu> ();

		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (thePauseMenu.isPaused)
			return;

		startingTime -= Time.deltaTime;

		if (startingTime <= 0) {
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

		timeText.text = "" + Mathf.Round(startingTime);
	}
}
