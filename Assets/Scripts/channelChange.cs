using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class channelChange : MonoBehaviour {

    public GameObject sphere;
    int counter = 0;
    public Texture t0;
    public Texture t1;
    public Texture t2;
    public Texture t3;
    public Texture t4;
    public Texture t5;
    public Texture t6;
    Texture[] textures;

    // Use this for initialization
    void Start () {
        // Create a material with transparent diffuse shader
        textures = new Texture[] { t0,t1,t2,t3,t4,t5,t6 };
    }
	
	// Update is called once per frame
	void Update () {
        float a = Input.GetAxis("Mouse X");
        if (a > 10)
        {
            counter++;
            counter = counter % textures.Length;
        }
        sphere.GetComponent<Renderer>().material.mainTexture = textures[counter];
        }
}
