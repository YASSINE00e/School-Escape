using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenProjector : MonoBehaviour
{
    [SerializeField] private GameObject pc;
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject projectorText;
    [SerializeField] private OpenProjector script;

    private bool inReach;


    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            projectorText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            projectorText.SetActive(false);

        }
    }




    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            lights.SetActive(true);
            Destroy(projectorText);
            script.enabled = false;
        }


    }
}
