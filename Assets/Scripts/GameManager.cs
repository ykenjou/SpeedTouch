using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager GetController() {
		return GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}

	CircleCreateController circleCreateController;

	[System.NonSerialized]
	public bool gameStartBool;
	[System.NonSerialized]
	public bool gameOverBool;
	public bool gameClearBool;
	[System.NonSerialized]
	public int score;
	public int oldScore;
	[System.NonSerialized]
	public int life;
	int oldLife;
	[System.NonSerialized]
	public int maxCircleCount;
	public int nowCircleCount;
	int oldCircleCount;

	public double circleIntervalD;
	double circleInterval;
	float gameTime;

	public Text scoreText;
	public Text lifeText;
	public Text countText;
	public Text timeText;
	public GameObject goText;
	public GameObject readyText;
	public GameObject gameOverView;
	public GameObject gameClearView;
	public GameObject startBtn;
	public GameObject headerPanel;
	GameModeController gameModeController;

	void Awake(){
		circleCreateController = CircleCreateController.GetController();
		gameModeController = GameModeController.GetController();
	}

	// Use this for initialization
	void Start () {
		maxCircleCount = 20;
		GameReset();
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStartBool && !gameClearBool && !gameOverBool){
			if(gameModeController.gameMode == "stream"){
				gameTime += Time.deltaTime;
				timeText.text = gameTime.ToString("f1");
			} else if(gameModeController.gameMode == "free"){
				
			} else {
				circleInterval += Time.deltaTime;
				if(circleInterval > circleIntervalD){
					switch(gameModeController.gameMode){
					case "single":
						circleCreateController.SetCircle();
						circleCreateController.ClearPosLists();
						break;
					case "double":
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.ClearPosLists();
						break;
					case "triple":
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.ClearPosLists();
						break;
					case "fourth":
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.ClearPosLists();
						break;
					case "fifth":
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.SetCircle();
						circleCreateController.ClearPosLists();
						break;
					}
					nowCircleCount++;
					circleInterval = 0;
				}
			}
		}

		if(score != oldScore){
			scoreText.text = score.ToString();
			oldScore = score;
		}

		if(life != oldLife){
			lifeText.text = life.ToString();
			oldLife = life;
		}

		if(nowCircleCount != oldCircleCount){
			countText.text = nowCircleCount.ToString() + "/" + maxCircleCount.ToString();
			oldCircleCount = nowCircleCount;
		}

		/*
		if(life <= 0 && gameOverBool == false){
			gameOverBool = true;
			StartCoroutine("GameOverStream");
		}
		*/

		if(gameClearBool){
			StartCoroutine("GameClearStream");
		}
	}

	public void GameReset(){
		gameStartBool = false;
		gameOverBool = false;
		gameClearBool = false;
		life = 3;
		lifeText.text = life.ToString();
		gameTime = 0.0f;
		//circleIntervalD = 1;
		circleInterval = 0;
		score = 0;
		nowCircleCount = 0;
		countText.text = nowCircleCount.ToString() + "/" + maxCircleCount.ToString();
		gameOverView.SetActive(false);
		gameClearView.SetActive(false);
		readyText.SetActive(true);
		goText.SetActive(false);
		startBtn.SetActive(true);
		if(gameModeController.gameMode == "stream"){
			timeText.gameObject.SetActive(true);
			scoreText.gameObject.SetActive(false);
			headerPanel.SetActive(true);
			gameModeController.footerPanel.SetActive(false);
		} else if(gameModeController.gameMode == "free"){
			headerPanel.SetActive(false);
		} else {
			timeText.gameObject.SetActive(false);
			scoreText.gameObject.SetActive(true);
			headerPanel.SetActive(true);
			gameModeController.footerPanel.SetActive(false);
		}
	}

	public void DoGameStartCoroutine(){
		StartCoroutine("GameStartStream");
	}

	IEnumerator GameClearStream(){
		gameStartBool = false;
		gameClearBool = false;
		yield return new WaitForSeconds(2.5f);
		gameClearView.SetActive(true);
	}

	IEnumerator GameOverStream(){
		gameStartBool = false;
		yield return new WaitForSeconds(1.0f);
		gameOverView.SetActive(true);
	}

	IEnumerator GameStartStream(){
		startBtn.SetActive(false);
		readyText.SetActive(false);
		goText.SetActive(true);
		yield return new WaitForSeconds(1.0f);
		goText.SetActive(false);
		gameStartBool = true;
		if(gameModeController.gameMode == "stream"){
			circleCreateController.SetStreamCircle();
		}
		/*
		if(gameModeController.gameMode == "free"){
			headerPanel.SetActive(false);
		}*/
	}

	/*

	IEnumerator GameResultStream(){
		
	}
	*/
		
}