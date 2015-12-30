using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircleController : MonoBehaviour {

	double circleExistTime;

	GameManager gameManager;
	CircleCreateController circleCreateController;
	RectTransform circleScoreTextForm;
	Text circleScoreText;

	void Awake(){
		gameManager = GameManager.GetController();
		circleCreateController = CircleCreateController.GetController();
	}

	// Use this for initialization
	void Start () {
		circleExistTime = gameManager.circleIntervalD * 0.2;
	}

	// Update is called once per frame
	void Update () {
		circleExistTime -= Time.deltaTime;
		if(circleExistTime < 0){
			gameManager.life--;
			Destroy(gameObject);
		}
	}

	public void ClickCircle(){
		double addScore = circleExistTime * 100;
		int addScoreInt = (int)addScore * 10;

		circleScoreTextForm = GameObject.Instantiate(circleCreateController.circleScoreTextPrefab) as RectTransform;
		circleScoreText = circleScoreTextForm.gameObject.GetComponentInChildren<Text>();
		circleScoreText.text = "+" + addScoreInt.ToString();
		circleScoreTextForm.SetParent(circleCreateController.gameCanvas,false);
		Vector2 circleScoreTextPos = circleScoreTextForm.anchoredPosition;
		circleScoreTextPos.y = circleCreateController.randomY + 100;
		circleScoreTextPos.x = circleCreateController.randomX;
		circleScoreTextForm.anchoredPosition = circleScoreTextPos;

		gameManager.score += addScoreInt;

		Destroy(gameObject);
	}
		
}
