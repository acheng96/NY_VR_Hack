using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class channelChange : MonoBehaviour {

    public GameObject sphere;
    Material[] mats;
    int counter = 0;

	// Use this for initialization
	void Start () {
        // Create a material with transparent diffuse shader
        mats = new Material[]{ new Material(Shader.Find("picnic")), new Material(Shader.Find("concert"))};
    }
	
	// Update is called once per frame
	void Update () {
        float a = Input.GetAxis("Mouse X");
        if (a > 5)
        {
            counter++;
            counter = counter % 2;
        }

        sphere.GetComponent<Renderer>().material = mats[counter];
    }
}
