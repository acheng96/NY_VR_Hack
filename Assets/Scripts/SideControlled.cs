using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controller for the home button, back button, and touch pad on the side of the Gear VR.
 */
public class SideControlled : MonoBehaviour {

	public static SideControlled singleton;

    [SerializeField]
    private GameObject colorMe;
    [SerializeField]
    private GameObject lerpMe;

    private Renderer rend;
    private Renderer lerp;

	// Use this for initialization
	void Awake () {
		singleton = this;
        rend = colorMe.GetComponent<Renderer>();
        lerp = lerpMe.GetComponent<Renderer>();
	}
	
	// Update is called once per frame. Used for button inputs
	void Update () {
        if(Input.GetButtonDown("Oculus_GearVR_LIndexTrigger") || Input.GetButtonDown("Oculus_GearVR_RIndexTrigger")){
            rend.material.SetColor("_Color", Color.red);
        }
        if(Input.GetButtonUp("Oculus_GearVR_LIndexTrigger") || Input.GetButtonUp("Oculus_GearVR_RIndexTrigger")){
            rend.material.SetColor("_Color", Color.white);
		}

        if(Input.GetButtonDown("Fire1")){
            rend.material.SetColor("_Color", Color.red);
        }
        if(Input.GetButtonUp("Fire1")){
            rend.material.SetColor("_Color", Color.white);
        }

	}

	//Used for swiping actions.
	void FixedUpdate () {
        //float a = (Input.GetAxis("Oculus_GearVR_DpadY")+1)/2;
        float a = (Input.GetAxis("vertical")+1)/2;
        lerp.material.SetColor("_Color", Color.Lerp(Color.white, Color.green, a));
	}
}
