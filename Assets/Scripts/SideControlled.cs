using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controller for the home button, back button, and touch pad on the side of the Gear VR.
 */
public class SideControlled : MonoBehaviour {

	public static SideControlled singleton;

	// Use this for initialization
	void Awake () {
		singleton = this;
	}
	
	// Update is called once per frame. Used for button inputs
	void Update () {
        if(Input.GetButtonUp("Oculus_GearVR_LIndexTrigger") || Input.GetButtonUp("Oculus_GearVR_RIndexTrigger")){
			Debug.Log("button pressed!");
		}
	}

	//Used for swiping actions.
	void FixedUpdate () {
		float a = Input.GetAxis("Oculus_GearVR_DpadY");
		if (Mathf.Abs(a) > 0.005){
			Debug.Log(a);
		}
	}
}
