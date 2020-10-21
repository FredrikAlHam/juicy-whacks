using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Hole : MonoBehaviour
{
    [SerializeField] public bool IsHit { get; private set; } = false;

    [SerializeField] public List<int> queue = new List<int>();
    public int beatIndex = 0;
    public float timeSinceLastBeat = 0;
    // Start is called before the first frame update

    public Animator animator;
    public AnimationClip anim;

    public Animator animatorAxe;
    public AnimationClip axeAnim;

    public Animator animatorOSU;


    SpriteRenderer sR = null;
    // Use this for initialization
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    public virtual void Hit()
    {
        animatorAxe.SetTrigger("Swing");
        IsHit = true;
    }

    public virtual void UnHit()
    {
        animatorAxe.SetTrigger("UnSwing");
        IsHit = false;
    }

    public virtual void PrepareToPopup()
    {
        animatorOSU.SetTrigger("OSU");
    }
    public virtual void Popup()
    {
        animatorOSU.SetTrigger("No");
        animator.SetTrigger("PopUp");
        timeSinceLastBeat = 0f;
        sR.color = Color.green;
    }
    public virtual void UnPopup()
    {
        animator.SetTrigger("UnPopUp");
        timeSinceLastBeat += Time.deltaTime;
        sR.color = Color.white;
    }
    protected virtual void Update()
    {
        try
        {
            if (queue.Count == 0 || queue.Count < beatIndex) return;
            else if (queue[beatIndex] > 0)
            {
                Popup();
            }
            else if (queue[beatIndex - 3] > 0)
            {
                UnPopup();
            }
            else if (queue[beatIndex + 4] > 0)
            {
                PrepareToPopup();
            }
        }
        catch (ArgumentOutOfRangeException)
        {

        }
    }
}
