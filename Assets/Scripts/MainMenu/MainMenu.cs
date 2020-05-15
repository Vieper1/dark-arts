using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour {

	public enum LevelType {
		Tutorial,
		Easy,
		Medium,
        Hard
	}

	private Animator anim;
	public static bool isSplashDirty;

	





	void Start () {
		
	}







	// Game Over Event
	//void OnEnable() {
	//	StartCoroutine(SubscribeCoroutine());
	//}
	//IEnumerator SubscribeCoroutine() {
	//	yield return new WaitForSeconds(0.5f);
	//	GameController.Instance.OnGameOver += OnGameOver;
	//}
	//void OnDisable() {
	//	GameController.Instance.OnGameOver -= OnGameOver;
	//	AdsController.HideBanner();
	//}
	//void OnGameOver() {
	//	anim.SetInteger("MenuState", (int)MenuState.MainMenu);
	//	isSplashDirty = true;
	//}
}
