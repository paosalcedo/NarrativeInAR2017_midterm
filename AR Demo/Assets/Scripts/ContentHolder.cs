using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ContentHolder : MonoBehaviour {

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
		"\"KnockDown\"",
		"\"Clotheshorse\""
	};
	private string[] names = {
		"Corey Bertelsen, MFA Game Design 2018",
		"Corey Bertelsen, MFA Game Design 2018",
		"Hang Ruan, MFA Game Design 2018"
	};

	ushort ushort1 = 0;
	// Use this for initialization

	void Awake(){
		videoPlayer = content.GetComponent<VideoPlayer>();
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		videoPlayer.SetTargetAudioSource(ushort1, audioSource);
	}
	void Start () {
		gameNameText.text = gameNames[nameNum];
		nameText.text = names[nameNum];
		videoPlayer.clip = clips[currentClipNum];
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void NextContent(){
		currentClipNum += 1;
		
		videoPlayer.clip = clips[currentClipNum];
		
		if(currentClipNum >= clips.Length-1){
			currentClipNum = 0;
		}
		return;
		// content.SetActive(true);	
		// videoPlayer.Play();
	}
}
