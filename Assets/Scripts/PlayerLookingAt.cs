using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookingAt : MonoBehaviour
{

    Transform cameraTransform = null;
    public Transform reticle;
    public string prevScene;

    void Awake()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 rayTo = reticle.position;
        Vector3 rayStart = cameraTransform.position;     // Start the ray away from the player to avoid hitting itself
        Vector3 rayDirection = rayTo - rayStart;
        Debug.DrawRay(rayStart, rayDirection, Color.green);

        if (Input.GetKeyDown(KeyCode.Escape))
            loadScene(prevScene);

        if (Physics.Raycast(rayStart, rayDirection, out hit))
        {
            if (hit.collider.tag == "Button")
            {
                hit.collider.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                hit.collider.GetComponent<UnityEngine.UI.Image>().color = new Color(76f / 255f, 255f / 255f, 159f / 255f);
                hit.collider.GetComponentInChildren<UnityEngine.UI.Text>().color = new Color(76f / 255f, 255f / 255f, 159f / 255f);
            } 
            
            if (hit.collider.tag == "RandomButton")
            {
                hit.collider.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                hit.collider.GetComponentInChildren<UnityEngine.UI.Text>().color = new Color(76f / 255f, 255f / 255f, 159f / 255f);
            }

            if (Input.GetButtonUp("Fire1"))
            {
                hit.collider.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            }
        } else
        {
            ResetMenuButtons();
        }
    }

    void ResetMenuButtons()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Button"))
        {
            g.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            g.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            g.GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;

        }

        if (GameObject.FindWithTag("RandomButton") != null)
        {
            GameObject.FindWithTag("RandomButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            GameObject.FindWithTag("RandomButton").GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;
        }
    }

    public void loadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}