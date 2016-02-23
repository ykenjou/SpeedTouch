using UnityEngine;
using System.Collections;

public class SoundCotroller : MonoBehaviour {

	public static SoundCotroller GetController() {
		return GameObject.FindGameObjectWithTag ("SoundCotroller").GetComponent<SoundCotroller>();
	}

	public AudioSource touchLightSound;
	public AudioClip fireworks2;
	public AudioClip touchBtn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void touchLightSoundPlay(){
		//touchLightSound.Play();
		touchLightSound.PlayOneShot(fireworks2);
	}

	public void touchBtnSoundPlay(){
		//touchLightSound.Play();
		touchLightSound.PlayOneShot(touchBtn);
	}
}
