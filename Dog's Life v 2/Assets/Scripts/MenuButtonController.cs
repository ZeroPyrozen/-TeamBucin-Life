using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	[SerializeField] public bool keyDown;
	[SerializeField] public int maxIndex;
	public AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		//if(Input.GetAxis ("Vertical") != 0){
		//	if(!keyDown){
		//		if (Input.GetAxis ("Vertical") < 0) {
		//			if(index < maxIndex){
		//				index++;
		//			}else{
		//				index = 0;
		//			}
		//		} else if(Input.GetAxis ("Vertical") > 0){
		//			if(index > 0){
		//				index --; 
		//			}else{
		//				index = maxIndex;
		//			}
		//		}
		//		keyDown = true;
		//	}
		//}else{
		//	keyDown = false;
		//}
        if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow)){
			if(!keyDown){
				if (Input.GetKeyDown(KeyCode.DownArrow)) {
					if(index < maxIndex){
						index++;
					}else{
						index = 0;
					}
				} else if(Input.GetKeyDown(KeyCode.UpArrow)){
					if(index > 0){
						index --; 
					}else{
						index = maxIndex;
					}
				}
				keyDown = true;
			}
		}else{
			keyDown = false;
		}
	}

}
