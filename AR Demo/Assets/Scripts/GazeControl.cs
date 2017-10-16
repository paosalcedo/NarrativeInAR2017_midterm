using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeControl : MonoBehaviour {

	public Image gazeProgressImg;
 	private float gazeTime = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// ShootRay();
		DetectTouchWorld();
	}

	public void ShootRay(){
	
		Ray ray = new Ray(transform.position, transform.forward);

		RaycastHit rayHit = new RaycastHit();

		if(Physics.Raycast (ray, out rayHit, Mathf.Infinity)){
 			if(rayHit.transform.name == "NextVidButton"){ 
				gazeTime += Time.deltaTime;					
				gazeProgressImg.fillAmount = gazeTime/3;

				if(gazeTime >= 3f){
					//trigger something.
					rayHit.transform.GetComponent<ContentHolder>().NextContent();
 					gazeTime = 0f;
					gazeProgressImg.fillAmount = 0;
					return;
				}   
			} else {
				if(gazeTime >= 0){
					gazeProgressImg.fillAmount = gazeTime/3;
					gazeTime -= Time.deltaTime * 2;
				}
			}
		}
	}
	public void DetectTouchWorld() {
        for (var i = 0; i < Input.touchCount; ++i) {
             if (Input.GetTouch(i).phase == TouchPhase.Began) {
                 // Construct a ray from the current touch coordinates
                 Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				 RaycastHit raycastHit = new RaycastHit();
                 // Create a particle if hit
                 if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity)){
					//  Application.Quit();
					 if(raycastHit.transform.name == "NextVidButton"){
						 if(!raycastHit.transform.GetComponent<ContentHolder>().hasBeenPressed){ //has not been pressed, play AwakeContent
							raycastHit.transform.GetComponent<ContentHolder>().AwakeContent();
						 } else{
							raycastHit.transform.GetComponent<ContentHolder>().NextContent();
						 }
					 }

					 if (raycastHit.transform.tag == "Exit"){
						 Application.Quit();
						 Debug.Log("hehehe");
					 }
				 }
             }
         }
     }
}
