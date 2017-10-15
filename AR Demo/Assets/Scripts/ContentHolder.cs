﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ContentHolder : MonoBehaviour {

	public GameObject content;
	public VideoClip[] clips;
	private VideoPlayer videoPlayer;
	// Use this for initialization
	void Start () {
		videoPlayer = content.GetComponent<VideoPlayer>();

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ActivateContent(){
		content.SetActive(true);	
		videoPlayer.Play();
	}
}
