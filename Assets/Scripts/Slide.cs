using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MicroscopePart
{
    [SerializeField]
    public string[] animationTriggers;
    private int numClick = 0;


    public void OnPartClicked()
    {
        numClick++;
        if (numClick == animationTriggers.Length)
        {
            numClick = 0;
            return;
        }
    }
    public override void Show()
    {
        
        foreach (Animator animator in partAnimator)
        {
            animator.SetTrigger(animationTriggers[numClick]);
        }
        OnPartClicked();
    }
}
