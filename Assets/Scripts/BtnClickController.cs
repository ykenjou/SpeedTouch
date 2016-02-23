using UnityEngine;
using System.Collections;

public class BtnClickController : MonoBehaviour {

	GameManager gameManager;
	SoundCotroller soundController;
	public GameObject gameModePanel;

	void Awake(){
		gameManager = GameManager.GetController();
		soundController = SoundCotroller.GetController();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickStartBtn(){
		gameManager.DoGameStartCoroutine();
		soundController.touchBtnSoundPlay();
	}

	public void ClickRestartBtn(){
		gameManager.GameReset();
		soundController.touchBtnSoundPlay();
	}

	public void ClickSelectBtn(){
		gameModePanel.SetActive(true);
		soundController.touchBtnSoundPlay();
	}

	public void ClickEndBtn(){
		gameManager.gameStartBool = false;
		gameModePanel.SetActive(true);
		soundController.touchBtnSoundPlay();
	}
}
