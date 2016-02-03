using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StreamCircleController : MonoBehaviour {

	GameManager gameManager;
	CircleCreateController circleCreateController;

	RectTransform particleForm;
	float alphaF;
	Image circleImage;

	void Awake(){
		gameManager = GameManager.GetController();
		circleCreateController = CircleCreateController.GetController();
	}

	// Use this for initialization
	void Start () {
		alphaF = 0.0f;
		circleImage = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		alphaF += 0.1f;
		circleImage.color = new Color(1,1,1,alphaF);
	}

	public void ClickCircle(){
		RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

		particleForm = GameObject.Instantiate(circleCreateController.particleContainer);
		particleForm.SetParent(circleCreateController.gameCanvas,false);
		Vector2 particlePos = particleForm.anchoredPosition;
		particlePos.y = rectTransform.anchoredPosition.y;
		particlePos.x = rectTransform.anchoredPosition.x;
		particleForm.anchoredPosition = particlePos;

		if(gameManager.nowCircleCount == gameManager.maxCircleCount){
			gameManager.gameClearBool = true;
		} else {
			circleCreateController.SetStreamCircle();			
		}

		Destroy(gameObject);
	}
}
