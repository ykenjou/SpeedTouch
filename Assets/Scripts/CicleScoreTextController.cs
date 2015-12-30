using UnityEngine;
using System.Collections;

public class CicleScoreTextController : MonoBehaviour {

	double destroyInterval;
	double addInterval;

	// Use this for initialization
	void Start () {
		destroyInterval = 1;
	}
	
	// Update is called once per frame
	void Update () {
		addInterval += Time.deltaTime;
		if(addInterval > destroyInterval){
			Destroy(gameObject);
		}
	}
}
