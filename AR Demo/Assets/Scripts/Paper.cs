using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class Paper : MonoBehaviour {

 	public GameObject content;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ActivateContent(){
		content.SetActive(true);	
	}
}
