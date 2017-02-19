using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChanger : MonoBehaviour {

    public GameObject sphere;
    public Texture t;
    public UnityEngine.UI.Button b;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (b.GetComponent<UnityEngine.UI.Image>().color.Equals(new Color(76f / 255f, 255f / 255f, 159f / 255f)))
            sphere.GetComponent<Renderer>().material.mainTexture = t;
    }
}
