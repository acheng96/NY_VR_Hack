using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookingAt : MonoBehaviour
{

    Transform cameraTransform = null;

    void Awake()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
    }

    void Update()
    {
        float length = 10.0f;
        RaycastHit hit;
        Vector3 rayDirection = cameraTransform.TransformDirection(Vector3.forward);
        Vector3 rayStart = cameraTransform.position + rayDirection;     // Start the ray away from the player to avoid hitting itself
        Debug.DrawRay(rayStart, rayDirection * length, Color.green);
        if (Physics.Raycast(rayStart, rayDirection, out hit, length))
        {
            if (hit.collider.tag == "CityButton" || hit.collider.tag == "CountryButton" ||
                hit.collider.tag == "OutdoorButton" || hit.collider.tag == "RandomButton")
            {
                hit.collider.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                hit.collider.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}