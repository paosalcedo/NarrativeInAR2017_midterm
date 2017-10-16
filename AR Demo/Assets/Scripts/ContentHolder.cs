using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class ContentHolder : MonoBehaviour, ITrackableEventHandler {

	public GameObject exitButtonGO;
	public TextMesh playText;
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
		content.SetActive(false);
		exitButtonGO.SetActive(false);
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
		videoPlayer.clip = clips[currentClipNum];
 	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AwakeContent(){
		if(!hasBeenPressed){
			exitButtonGO.SetActive(true);
			content.SetActive(true);
			gameNameText.text = gameNames[currentClipNum];
			gameNameText.fontSize = 54;
			nameText.text = names[currentClipNum];
			videoPlayer.Play();
			hasBeenPressed = true;
			playText.text = "Next";
		}
	}
	public void NextContent(){
		if(hasBeenPressed){
			playText.text = "Next";
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

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus){
		 if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
				videoPlayer.Play();
				Debug.Log("video playing!");
            }
            else
            {
				videoPlayer.Stop();
				Debug.Log("video stopped!");
            }
	}


}
