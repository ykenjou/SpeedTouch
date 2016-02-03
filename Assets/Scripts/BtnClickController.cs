using UnityEngine;
using System.Collections;

public class BtnClickController : MonoBehaviour {

	GameManager gameManager;
	public GameObject gameModePanel;

	void Awake(){
		gameManager = GameManager.GetController();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickStartBtn(){
		gameManager.DoGameStartCoroutine();
	}

	public void ClickRestartBtn(){
		gameManager.GameReset();
	}

	public void ClickSelectBtn(){
		gameModePanel.SetActive(true);
	}

	public void ClickEndBtn(){
		gameManager.gameStartBool = false;
		gameModePanel.SetActive(true);
	}
}
