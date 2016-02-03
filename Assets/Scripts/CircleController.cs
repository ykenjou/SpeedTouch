using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircleController : MonoBehaviour {

	double circleExistTime;

	GameManager gameManager;
	CircleCreateController circleCreateController;
	RectTransform circleScoreTextForm;
	Text circleScoreText;
	RectTransform particleForm;
	public RectTransform selectedParticle;
	float alphaF;
	Image circleImage;

	void Awake(){
		gameManager = GameManager.GetController();
		circleCreateController = CircleCreateController.GetController();
		selectedParticle = circleCreateController.particleContainer;
	}

	// Use this for initialization
	void Start () {
		alphaF = 0.0f;
		circleImage = gameObject.GetComponent<Image>();
		circleExistTime = gameManager.circleIntervalD * 0.8;
	}

	// Update is called once per frame
	void Update () {
		
		alphaF += 0.1f;
		circleImage.color = new Color(1,1,1,alphaF);

		circleExistTime -= Time.deltaTime;
		if(circleExistTime < 0){
			gameManager.life--;
			if(gameManager.life > 0 && gameManager.nowCircleCount == gameManager.maxCircleCount){
				gameManager.gameClearBool = true;
			}
			Destroy(gameObject);
		}
	}

	public void ClickCircle(){
		double addScore = circleExistTime * 100;
		int addScoreInt = (int)addScore * 10;
		if(addScoreInt == 0){
			addScoreInt = 10;
		}
		gameManager.score += addScoreInt;

		RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

		/*
		circleScoreTextForm = GameObject.Instantiate(circleCreateController.circleScoreTextPrefab) as RectTransform;
		circleScoreText = circleScoreTextForm.gameObject.GetComponentInChildren<Text>();
		circleScoreText.text = "+" + addScoreInt.ToString();
		circleScoreTextForm.SetParent(circleCreateController.gameCanvas,false);
		Vector2 circleScoreTextPos = circleScoreTextForm.anchoredPosition;
		circleScoreTextPos.y = rectTransform.anchoredPosition.y + 200;
		circleScoreTextPos.x = rectTransform.anchoredPosition.x;
		circleScoreTextForm.anchoredPosition = circleScoreTextPos;
		*/

		particleForm = GameObject.Instantiate(selectedParticle);
		particleForm.SetParent(circleCreateController.gameCanvas,false);
		Vector2 particlePos = particleForm.anchoredPosition;
		particlePos.y = rectTransform.anchoredPosition.y;
		particlePos.x = rectTransform.anchoredPosition.x;
		particleForm.anchoredPosition = particlePos;

		if(gameManager.nowCircleCount == gameManager.maxCircleCount){
			gameManager.gameClearBool = true;
		}

		Destroy(gameObject);
	}
		
}
