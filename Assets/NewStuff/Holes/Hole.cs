using System;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] public bool IsHit { get; private set; } = false;

    [SerializeField] public List<int> queue = new List<int>();
    public int beatIndex = 0;
    public float timeSinceLastBeat = 0;
    // Start is called before the first frame update

    [SerializeField] private bool isPopUp = false;
    [SerializeField] private bool hasBeenhit = false;
    [SerializeField] private bool isPreparing = false;

    public Animator animator;  //animator that controls (beavers) when to animate
    public AnimationClip anim;

    public Animator animatorAxe;  //animator that controls (Axe) when to animate
    public AnimationClip axeAnim;

    public Animator animatorOSU;  //animator that controls (circle/feedback thingy) when to animate


    SpriteRenderer sR = null;
    // Use this for initialization
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    public virtual void Hit()
    {
        animatorAxe.SetTrigger("Swing");  //when you hit (i.e. Press (L, K, J, F, D or S)) it will play this animation
        if (isPopUp && !hasBeenhit)
        {
            hasBeenhit = true;
            Score.instance.score++;
        }
        else
        {
            Score.instance.score--;
        }
        IsHit = true;  //Activate true/false statement so that the game knows that one of these keys are pressed
    }

    public virtual void UnHit()
    {
        animatorAxe.SetTrigger("UnSwing");
        IsHit = false;
    }

    public virtual void PrepareToPopup()
    {
        animatorOSU.SetTrigger("OSU");
        isPreparing = true;
    }
    public virtual void Popup()
    {
        isPreparing = false;
        animator.SetTrigger("PopUp");
        animatorOSU.SetTrigger("No");
        timeSinceLastBeat = 0f;
        sR.color = Color.green;
        isPopUp = true;
        hasBeenhit = false;
    }



    public virtual void UnPopup()
    {
        if(!hasBeenhit) Score.instance.score--;
        animator.SetTrigger("UnPopUp");
        timeSinceLastBeat += Time.deltaTime;
        sR.color = Color.white;
        isPopUp = false;
    }
    protected virtual void Update()
    {
        //There must be a better way to do this
        try
        {
            if (queue[beatIndex] > 0 && !isPopUp)
            {
                Popup();
            }
            if (queue[beatIndex - 3] > 0 && isPopUp)
            {
                UnPopup();
            }
            if (queue[beatIndex + 3] > 0 && !isPreparing)
            {
                PrepareToPopup();
            }
        }
        catch (ArgumentOutOfRangeException)
        {

        }
    }
}
