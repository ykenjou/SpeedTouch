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
	[System.NonSerialized]
	public int life;
	[System.NonSerialized]
	public int maxCircleCount;
	public int nowCircleCount;

	public double circleIntervalD;
	double circleInterval;

	public Text scoreText;
	public Text lifeText;
	public Text countText;
	public GameObject gameOverView;
	public GameObject gameClearView;

	void Awake(){
		circleCreateController = CircleCreateController.GetController();
	}

	// Use this for initialization
	void Start () {
		maxCircleCount = 50;
		GameReset();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameStartBool && !gameClearBool && !gameOverBool){
			circleInterval += Time.deltaTime;
			if(circleInterval > circleIntervalD){
				circleCreateController.SetCircle();
				nowCircleCount++;
				circleInterval = 0;
			}
		}


		scoreText.text = score.ToString();
		lifeText.text = life.ToString();
		countText.text = nowCircleCount.ToString() + "/" + maxCircleCount.ToString();

		if(life <= 0){
			gameOverBool = true;
			gameOverView.SetActive(true);
		}
	}

	public void GameReset(){
		gameStartBool = false;
		gameOverBool = false;
		gameClearBool = false;
		life = 3;
		circleIntervalD = 3;
		circleInterval = 0;
		score = 0;
		nowCircleCount = 0;
		gameOverView.SetActive(false);
		gameClearView.SetActive(false);
	}


	IEnumerator GameStartStream(){
		yield return new WaitForSeconds(1.0f);
	}

	/*

	IEnumerator GameResultStream(){
		
	}
	*/
		
}