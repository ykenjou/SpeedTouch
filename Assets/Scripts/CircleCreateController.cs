using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircleCreateController : MonoBehaviour {

	public static CircleCreateController GetController() {
		return GameObject.FindGameObjectWithTag ("CircleCreateController").GetComponent<CircleCreateController>();
	}

	//GameManager gameManager;

	public RectTransform circle1Prefab;
	private RectTransform circle1;
	public RectTransform circleScoreTextPrefab;

	public Transform gameCanvas;

	public int randomY;
	public int randomX;

	void Awake(){
		//gameManager = GameManager.GetController();
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
		randomY = Random.Range(-200,-1100);
		randomX = Random.Range(150,600);
		Vector2 circle1Pos = circle1.anchoredPosition;
		circle1Pos.y = randomY;
		circle1Pos.x = randomX;
		circle1.anchoredPosition = circle1Pos;
	}
}
