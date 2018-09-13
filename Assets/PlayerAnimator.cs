using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAnimator : MonoBehaviour
{

    private Animator playerAnimator;
    private AudioSource playerAudio;

    // Use this for initialization
    void Start()
    {


        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        // Store the input axes.
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        // Animate the player.动画物体
        Animating(h, v);
    }

    void Animating(float h, float v)
    {

        bool walking = h != 0f || v != 0f;


        playerAnimator.SetBool("isRun", walking);
    }
    public void onRun()
    {
        //Debug.Log("onRun");
        playerAnimator.SetBool("isRun", true);


    }
    public void onStop()
    {
        //Debug.Log("onStop");
        playerAnimator.SetBool("isRun", false);

    }
}
