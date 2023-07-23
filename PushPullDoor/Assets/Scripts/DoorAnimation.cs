using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{

    [SerializeField]
    Animator gameDoorAnim;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip doorOpen;
    [SerializeField]
    AudioClip doorClose;

    Instructions instructionScript;
    
     GameObject instructionObj;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PushDoor()
    {
        Debug.Log("Push Door called");
     if(Instructions.currentState == "PUSH")
        {
        gameDoorAnim.SetBool("doorPush",true);
        }
        StartCoroutine("defaultState");
        audioSource.clip = doorOpen;
        audioSource.PlayOneShot(doorOpen);
        
       
    }

    public void PullDoor()
    {
        Debug.Log("Pull Door called");
         if(Instructions.currentState == "PULL")
        {
        gameDoorAnim.SetBool("doorPull",true);
        }
        StartCoroutine("defaultStatePull");
         audioSource.clip = doorClose;
        audioSource.PlayOneShot(doorClose);
        

    }

    IEnumerator defaultState()
    {
        yield return new WaitForSeconds(0.8f);
        gameDoorAnim.SetBool("doorPush",false);
        gameDoorAnim.SetBool("doorPull",false);

        if(Instructions.currentState == "PUSH")
       {
        //Increase score
        Debug.Log("Change State called Push");
        GameObject.FindGameObjectWithTag("Instruction").GetComponent<Instructions>().ChangeState();
       }
    }

    IEnumerator defaultStatePull()
    {
        yield return new WaitForSeconds(0.8f);
        gameDoorAnim.SetBool("doorPush",false);
        gameDoorAnim.SetBool("doorPull",false);
        if(Instructions.currentState == "PULL")
        {
        //Increase score
        Debug.Log("Change State called Pull");
        GameObject.FindGameObjectWithTag("Instruction").GetComponent<Instructions>().ChangeState();
        }
    }
}
