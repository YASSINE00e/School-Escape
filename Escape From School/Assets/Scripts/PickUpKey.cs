using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    [SerializeField] private GameObject keyOB;
    [SerializeField] private GameObject invOB;
    [SerializeField] private GameObject pickUpText;
    //[SerializeField] private AudioSource keySound;

    [SerializeField] private bool inReach;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);

        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyOB.SetActive(false);
            //keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
        }


    }
}
