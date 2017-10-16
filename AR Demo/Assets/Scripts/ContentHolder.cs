using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ContentHolder : MonoBehaviour {

	public bool hasBeenPressed = false;
	public GameObject content;
	public AudioSource audioSource;
	public VideoClip[] clips;

	private VideoPlayer videoPlayer;
	int currentClipNum = 0;
	int nameNum = 0;

	public TextMesh gameNameText;
	public TextMesh nameText;

	private string[] gameNames = {
		"\"KnockDown\"",
		"\"Clotheshorse\""
	};
	private string[] names = {
		"Corey Bertelsen, MFA Game Design 2018",
		"Hang Ruan, MFA Game Design 2018"
	};

	ushort ushort1 = 0;
	// Use this for initialization

	void Awake(){
		videoPlayer = content.GetComponent<VideoPlayer>();
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		videoPlayer.SetTargetAudioSource(ushort1, audioSource);
		currentClipNum = Random.Range(0, 2);
	}
	void Start () {
		if(currentClipNum == 0) {
			nameNum = 0;
		} else {
			nameNum = 1;
		}
		gameNameText.text = gameNames[currentClipNum];
		nameText.text = names[currentClipNum];
		videoPlayer.clip = clips[currentClipNum];
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AwakeContent(){
		if(!hasBeenPressed){
			videoPlayer.Play();
			hasBeenPressed = true;
		}
	}
	public void NextContent(){
		if(hasBeenPressed){
			if(currentClipNum == 1){
				videoPlayer.Play();
				videoPlayer.playOnAwake = true;
 				currentClipNum = 0;
				videoPlayer.clip = clips[currentClipNum];
				gameNameText.text = gameNames[currentClipNum];
				nameText.text = names[currentClipNum];
			} else if (currentClipNum == 0) {
				videoPlayer.Play();
				videoPlayer.playOnAwake = true;
 				currentClipNum = 1;
				videoPlayer.clip = clips[currentClipNum];
				gameNameText.text = gameNames[currentClipNum];
				nameText.text = names[currentClipNum];
			}
		
			// if(currentClipNum >= clips.Length-1){
			// 	currentClipNum = Random.Range(0, 2);
			// 	gameNameText.text = gameNames[currentClipNum];
			// 	nameText.text = names[currentClipNum];
			// }
 		}
		// content.SetActive(true);	
	}


}
