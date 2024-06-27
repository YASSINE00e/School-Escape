using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedDoors : MonoBehaviour
{

    [SerializeField] private Animator door;
    [SerializeField] private GameObject keyOB;
    [SerializeField] private GameObject openText;
    //public GameObject closeText;
    [SerializeField] private GameObject lockedText;


    //[SerializeField] private AudioSource openSound;
    //[SerializeField] private AudioSource lockedSound;
    //[SerializeField] private AudioSource unlockedSound;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;
    [SerializeField] private bool locked;
    [SerializeField] private bool unlocked;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            lockedText.SetActive(false);

        }
    }

    void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        openText.SetActive(false);
        locked = true;
        unlocked = false;
    }




    void Update()
    {


        if (inReach && keyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            //unlockedSound.Play();
            locked = false;
            keyOB.SetActive(false);
            StartCoroutine(unlockDoor());
        }

        if (inReach && doorisClosed && unlocked && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", true);
            openText.SetActive(false);
            //openSound.Play();
            doorisOpen = true;
            doorisClosed = false;
        }

        if (inReach && locked && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            lockedText.SetActive(true);
            //lockedSound.Play();
        }

    }

    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(.05f);
        {

            unlocked = true;
        }
    }
}
