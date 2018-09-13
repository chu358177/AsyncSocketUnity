using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
enum StateCharacter
{
    Idle,Run,Rotate
}

enum StateDirection
{
    On,Off
}
public class PlayerState : MonoBehaviour {
    public testConnectToServer client;
    public Transform playerTrans;

    public Action OnChangeMotionIdle;
    public Action OnChangeMotionRun;
    public Action OnChangeRotate;
    StateCharacter stateChar;
    StateDirection stateDir;

    private float lastY;
    StateCharacter lastStateChar;
    StateDirection lastStateDir;
    // Use this for initialization
    void Start () {
        stateChar = StateCharacter.Idle;
        stateDir = StateDirection.Off;
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(v !=0 || h != 0)
        {
            stateChar = StateCharacter.Run;
        }else
        {
            stateChar = StateCharacter.Idle;
        }
        if(!Mathf.Approximately(playerTrans.rotation.eulerAngles.y,lastY))
        {
            stateDir = StateDirection.On;
        }
        else
        {
            stateDir = StateDirection.Off;
        }
        //Debug.Log("stateDir " + stateDir  + " | stateChar " + stateChar);
        HandleState();

        lastY = playerTrans.rotation.eulerAngles.y;
        lastStateChar = stateChar;
        lastStateDir = stateDir;

        
    }

    void HandleState()
    {
        if(stateChar != lastStateChar)
        {
            switch (stateChar)
            {
                case StateCharacter.Idle:
                    //client.SendToServer("Motion|Idle");
                    OnChangeMotionIdle?.Invoke();
                    break;
                case StateCharacter.Run:
                    //client.SendToServer("Motion|Run");
                    OnChangeMotionRun?.Invoke();
                    break;
            }

           // Debug.Log("Changed stateChar");
        }
        Debug.Log("stateDir " + stateDir + " | lastStateDir " + lastStateDir);
        if (stateDir != lastStateDir)
        {
            switch (stateDir)
            {
                case StateDirection.Off:
                    //client.SendToServer("Dir|" + playerTrans.rotation.eulerAngles.y.ToString("F5"));
                    OnChangeRotate?.Invoke();
                    break;
                case StateDirection.On:
                    break;
            }

            Debug.Log("Changed rotate");
        }
        
    }
}
