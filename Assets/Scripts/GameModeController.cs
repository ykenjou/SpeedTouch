using UnityEngine;
using System.Collections;

public class GameModeController : MonoBehaviour {

	public static GameModeController GetController() {
		return GameObject.FindGameObjectWithTag ("GameModeController").GetComponent<GameModeController>();
	}

	public string gameMode;
	public string gameType;
	public GameObject gameModePanel;
	public GameObject footerPanel;

	GameManager gameManager;

	void Awake(){
		gameManager = GameManager.GetController();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetCircleIntervalD(){
		switch(gameMode){
		case "single":
			gameManager.circleIntervalD = 1;
			break;
		case "double":
			gameManager.circleIntervalD = 1.6;
			break;
		case "triple":
			gameManager.circleIntervalD = 1.8;
			break;
		case "fourth":
			gameManager.circleIntervalD = 2.2;
			break;
		case "fifth":
			gameManager.circleIntervalD = 2.5;
			break;
		}
	}


	public void SetGameMode(string mode){
		gameMode = mode;
		SetCircleIntervalD();
		gameModePanel.SetActive(false);
		if(mode == "free"){
			footerPanel.SetActive(true);
		}
		gameManager.GameReset();
	}
}
