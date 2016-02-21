using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CircleCreateController : MonoBehaviour {

	public static CircleCreateController GetController() {
		return GameObject.FindGameObjectWithTag ("CircleCreateController").GetComponent<CircleCreateController>();
	}

	GameManager gameManager;
	GameModeController gameModeController;

	public RectTransform circleYellowPrefab;
	public RectTransform circleWaterPrefab;
	public RectTransform circleRedPrefab;
	public RectTransform circleWhitePrefab;
	public RectTransform circleLightGreenPrefab;
	private RectTransform circleContainer;

	private RectTransform circle1;
	public RectTransform circleScoreTextPrefab;

	public RectTransform streamCirclePrefab;
	private RectTransform streamCircle;


	public RectTransform particleYellowPrefab;
	public RectTransform particleWaterPrefab;
	public RectTransform particleRedPrefab;
	public RectTransform particleWhitePrefab;
	public RectTransform particleLightGreenPrefab;
	[System.NonSerialized]
	public RectTransform particleContainer;

	public Transform gameCanvas;
	public RectTransform gameCanvasForm;

	public int randomY;
	public int randomX;

	int marginY;
	int marginX;

	List<int> PosYList;
	List<int> posXList;

	int selectCircle;
	//int preSelectPrefab = 4;

	Vector2 gameCanvasSize;
	int gameCanvasWidth;

	void Awake(){
		gameManager = GameManager.GetController();
		gameModeController = GameModeController.GetController();
		randomY = 0;
		randomX = 0;
		PosYList = new List<int>();
		posXList = new List<int>();
	}

	// Use this for initialization
	void Start () {
		gameCanvasSize = gameCanvasForm.sizeDelta;
		gameCanvasWidth = (int)gameCanvasSize.x;
	}

	// Update is called once per frame
	void Update () {

	}

	void SelectCircle(){
		/*
		while(true){
			selectCircle = Random.Range(0,5);
			if(selectCircle != preSelectPrefab){
				break;
			}
		}
		switch(selectCircle){
		case 0:
			circleContainer = circleYellowPrefab;
			particleContainer = particleYellowPrefab;
			break;
		case 1:
			circleContainer = circleWaterPrefab;
			particleContainer = particleWaterPrefab;
			break;
		case 2:
			circleContainer = circleRedPrefab;
			particleContainer = particleRedPrefab;
			break;
		case 3:
			circleContainer = circleWhitePrefab;
			particleContainer = particleWhitePrefab;
			break;
		case 4:
			circleContainer = circleLightGreenPrefab;
			particleContainer = particleLightGreenPrefab;
			break;
		}

		preSelectPrefab = selectCircle;
		*/
		circleContainer = circleYellowPrefab;
		particleContainer = particleYellowPrefab;
	}

	public void SetCircle(){
		SelectCircle();
		circle1 = GameObject.Instantiate(circleContainer) as RectTransform;
		circle1.SetParent(gameCanvas,false);

		if(posXList.Count == 0){
			//randomY = Random.Range(-400,-1100);
			//randomX = Random.Range(200,600);

			randomY = Random.Range(-300,-1100);
			randomX = Random.Range(200,gameCanvasWidth - 200);
		} else {
			switch(gameModeController.gameMode){
			case "single":
				marginY = 100;
				marginX = 100;
				break;
			case "double":
				marginY = 150;
				marginX = (gameCanvasWidth-300) / 5;
				break;
			case "triple":
				marginY = 150;
				marginX = (gameCanvasWidth-300) / 6;
				break;
			case "fourth":
				marginY = 135;
				marginX = (gameCanvasWidth-300) / 7;
				break;
			case "fifth":
				marginY = 105;
				marginX = (gameCanvasWidth-300) / 8;
				break;
			}

			bool loopYBool = false;
			while(true){
				randomY = Random.Range(-200,-1100);
				for(int i = 0; i < PosYList.Count;i++){
					if(PosYList[i] + marginY < randomY || PosYList[i] - marginY > randomY){
						loopYBool = true;
					} else {
						loopYBool = false;
						break;
					}
				}
				if(loopYBool){
					break;
				}
			}

			bool loopXBool = false;
			while(true){
				randomX = Random.Range(150,gameCanvasWidth - 150);
				for(int i = 0; i < posXList.Count; i++){
					if(posXList[i] - marginX > randomX || posXList[i] + marginX < randomX){
						loopXBool = true;
					} else {
						loopXBool = false;
						break;
					}
				}
				if(loopXBool){
					break;
				}
			}
		}

		Vector2 circle1Pos = circle1.anchoredPosition;
		circle1Pos.y = randomY;
		circle1Pos.x = randomX;
		circle1.anchoredPosition = circle1Pos;
		PosYList.Add(randomY);
		posXList.Add(randomX);
	}

	public void SetStreamCircle(){
		particleContainer = particleYellowPrefab;
		streamCircle = GameObject.Instantiate(streamCirclePrefab) as RectTransform;
		streamCircle.SetParent(gameCanvas,false);

		randomY = Random.Range(-250,-1100);
		randomX = Random.Range(200,gameCanvasWidth - 200);
		Vector2 streamCirclePos = streamCircle.anchoredPosition;
		streamCirclePos.y = randomY;
		streamCirclePos.x = randomX;
		streamCircle.anchoredPosition = streamCirclePos;

		gameManager.nowCircleCount++;
	}

	public void ClearPosLists(){
		PosYList.Clear();
		posXList.Clear();
	}
}
