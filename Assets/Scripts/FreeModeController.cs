using UnityEngine;
using System.Collections;

public class FreeModeController : MonoBehaviour {

	CircleCreateController circleCreateController;
	GameModeController gameModeController;
	GameManager gameManager;

	void Awake(){
		circleCreateController = CircleCreateController.GetController();
		gameModeController = GameModeController.GetController();
		gameManager = GameManager.GetController();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameModeController.gameMode == "free" && gameManager.gameStartBool){
			if(Input.GetMouseButtonDown(0)){
				Vector3 touchPosition;
				touchPosition = Input.mousePosition;
				touchPosition.z = 10f;

				Instantiate(circleCreateController.particleContainer,Camera.main.ScreenToWorldPoint(touchPosition),Quaternion.identity);
			}
		}
	}
}

