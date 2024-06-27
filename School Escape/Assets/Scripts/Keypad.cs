using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keypad : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject keypadOB;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject inv;


    [SerializeField] private GameObject animateOB;
    [SerializeField] private Animator ANI;


    [SerializeField] private Text textOB;
    [SerializeField] private string answer = "12345";

    //[SerializeField] private AudioSource button;
    //[SerializeField] private AudioSource correct;
    //[SerializeField] private AudioSource wrong;



    void Start()
    {
        keypadOB.SetActive(false);

    }


    public void Number(int number)
    {
        textOB.text += number.ToString();
        //button.Play();
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            //correct.Play();
            textOB.text = "Right";

        }
        else
        {
            //wrong.Play();
            textOB.text = "Wrong";
        }


    }

    public void Clear()
    {
        {
            textOB.text = "";
            //button.Play();
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        cam.GetComponent<PlayerCam>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }

    public void Update()
    {
        if (textOB.text == "Right")
        {
            ANI.SetBool("Open", true);
            Debug.Log("its open");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }


        if (keypadOB.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = false;
            cam.GetComponent<PlayerCam>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }


}
