using UnityEngine;
using System.Collections;

public class BtnClickController : MonoBehaviour {

	GameManager gameManager;

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
		gameManager.gameStartBool = true;
	}

	public void RestartBtn(){
		gameManager.GameReset();
	}
}
