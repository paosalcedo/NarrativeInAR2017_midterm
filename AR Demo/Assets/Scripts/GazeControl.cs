using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeControl : MonoBehaviour {

 	private float gazeTime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ShootRay();
	}

	public void ShootRay(){
	
		Ray ray = new Ray(transform.position, transform.forward);
		
		RaycastHit rayHit = new RaycastHit();

		if(Physics.Raycast (ray, out rayHit, Mathf.Infinity)){
 			if(rayHit.transform.GetComponent<ContentHolder>() != null){ 
				gazeTime += Time.deltaTime;
				if(gazeTime >= 3f){
					//trigger something.
					rayHit.transform.GetComponent<ContentHolder>().ActivateContent();
 					gazeTime = 0f;
				}   
			}
		}
	}
}
