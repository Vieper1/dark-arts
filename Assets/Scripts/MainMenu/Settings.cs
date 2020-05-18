using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
	
	void Start () {
		if (PlayerPrefs.GetInt("SoundEnabled", 1) == 0) {
			transform.Find("SoundButton/Text").GetComponent<Text>().text = "Sound: OFF";
			AudioListener.pause = true;
		}
		if (PlayerPrefs.GetInt("FxaaEnabled", 0) == 0) {
			transform.Find("FxaaButton/Text").GetComponent<Text>().text = "Anti-Aliasing: OFF";
			GameObject.Find("Main Camera").GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.None;
		}
	}
	
	public void OnSoundTogglePressed() {
		if (PlayerPrefs.GetInt("SoundEnabled", 1) == 1) {
			PlayerPrefs.SetInt("SoundEnabled", 0);
			transform.Find("SoundButton/Text").GetComponent<Text>().text = "Sound: OFF";
			AudioListener.pause = true;
		} else {
			PlayerPrefs.SetInt("SoundEnabled", 1);
			transform.Find("SoundButton/Text").GetComponent<Text>().text = "Sound: ON";
			AudioListener.pause = false;
		}
	}

	public void OnFxaaTogglePressed() {
		if (PlayerPrefs.GetInt("FxaaEnabled", 1) == 1) {
			PlayerPrefs.SetInt("FxaaEnabled", 0);
			transform.Find("FxaaButton/Text").GetComponent<Text>().text = "Anti-Aliasing: OFF";
			GameObject.Find("Main Camera").GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.None;
		} else {
			PlayerPrefs.SetInt("FxaaEnabled", 1);
			transform.Find("FxaaButton/Text").GetComponent<Text>().text = "Anti-Aliasing: ON";
            GameObject.Find("Main Camera").GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
            GameObject.Find("Main Camera").GetComponent<PostProcessLayer>().subpixelMorphologicalAntialiasing.quality = SubpixelMorphologicalAntialiasing.Quality.High;
        }
	}
}
