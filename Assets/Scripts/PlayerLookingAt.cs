using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookingAt : MonoBehaviour
{

    Transform cameraTransform = null;
    public Transform reticle;

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
        if (Physics.Raycast(rayStart, rayDirection, out hit))
        {
            if (hit.collider.tag == "CityButton" || hit.collider.tag == "CountryButton" || hit.collider.tag == "NewYorkButton" ||
                hit.collider.tag == "OutdoorButton" || hit.collider.tag == "BookmarksButton" || hit.collider.tag == "Button")
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
        } else
        {
            ResetMenuButtons();
        }
    }

    void ResetMenuButtons()
    {
        GameObject.FindWithTag("CityButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.FindWithTag("CountryButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.FindWithTag("OutdoorButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.FindWithTag("BookmarksButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        if (GameObject.FindWithTag("RandomButton") != null)
            GameObject.FindWithTag("RandomButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        GameObject.FindWithTag("CityButton").GetComponent<UnityEngine.UI.Image>().color = Color.white;
        GameObject.FindWithTag("CountryButton").GetComponent<UnityEngine.UI.Image>().color = Color.white;
        GameObject.FindWithTag("OutdoorButton").GetComponent<UnityEngine.UI.Image>().color = Color.white;
        GameObject.FindWithTag("BookmarksButton").GetComponent<UnityEngine.UI.Image>().color = Color.white;

        GameObject.FindWithTag("CityButton").GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;
        GameObject.FindWithTag("CountryButton").GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;
        GameObject.FindWithTag("OutdoorButton").GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;
        GameObject.FindWithTag("BookmarksButton").GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;
        if (GameObject.FindWithTag("RandomButton") != null)
            GameObject.FindWithTag("RandomButton").GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Button"))
        {
            g.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            g.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            g.GetComponentInChildren<UnityEngine.UI.Text>().color = Color.white;

        }
    }
}