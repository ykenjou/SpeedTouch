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

	public RectTransform circle1Prefab;
	private RectTransform circle1;
	public RectTransform circleScoreTextPrefab;
	public RectTransform particlePrefab;

	public RectTransform streamCirclePrefab;
	private RectTransform streamCircle;

	public Transform gameCanvas;

	public int randomY;
	public int randomX;

	int marginY;
	int marginX;

	List<int> PosYList;
	List<int> posXList;


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

	}

	// Update is called once per frame
	void Update () {

	}

	public void SetCircle(){
		circle1 = GameObject.Instantiate(circle1Prefab) as RectTransform;
		circle1.SetParent(gameCanvas,false);

		if(posXList.Count == 0){
			randomY = Random.Range(-200,-1100);
			randomX = Random.Range(200,600);
		} else {
			switch(gameModeController.gameMode){
			case "single":
				marginY = 100;
				marginX = 100;
				break;
			case "double":
				marginY = 150;
				marginX = 150;
				break;
			case "triple":
				marginY = 150;
				marginX = 100;
				break;
			case "fourth":
				marginY = 140;
				marginX = 70;
				break;
			case "fifth":
				marginY = 110;
				marginX = 50;
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
				randomX = Random.Range(150,600);
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
		streamCircle = GameObject.Instantiate(streamCirclePrefab) as RectTransform;
		streamCircle.SetParent(gameCanvas,false);

		randomY = Random.Range(-200,-1100);
		randomX = Random.Range(200,600);
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
