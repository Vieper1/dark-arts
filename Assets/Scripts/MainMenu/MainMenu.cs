using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour {

	public enum LevelType {
        Main
	}

	





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
