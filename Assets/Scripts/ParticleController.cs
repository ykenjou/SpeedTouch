using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	double lifeTime;

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		lifeTime = 5;
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;
		if(lifeTime < 0){
			Destroy(gameObject);
		}
	}
}
