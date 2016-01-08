using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CicleScoreTextController : MonoBehaviour {

	double destroyInterval;
	double addInterval;
	Vector2 transformPos;
	Text transformText;
	float alphaF;

	// Use this for initialization
	void Start () {
		destroyInterval = 1;
		transformPos = transform.position;
		transformText = gameObject.GetComponent<Text>();
		alphaF = 1;
	}
	
	// Update is called once per frame
	void Update () {
		alphaF -= 0.01f;
		transformText.color = new Color(1,1,1,alphaF);
		transformPos.y = transformPos.y + 0.005f;
		transform.position = transformPos;
		addInterval += Time.deltaTime;
		if(addInterval > destroyInterval){
			Destroy(gameObject);
		}
	}
}
