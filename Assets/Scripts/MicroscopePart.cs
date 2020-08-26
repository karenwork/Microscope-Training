using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Base class for selecting a microscope part and triggering 
/// its part animations
/// </summary>
public class MicroscopePart : MonoBehaviour
{
    [SerializeField]
    public Animator[] partAnimator;

    [SerializeField]
    public string animationTrigger;

    [SerializeField]
    protected bool isSelected;

    public bool Selected { get { return this.isSelected; } set { isSelected = value; } }
    
    public virtual void Show ()
    {
        PlayPartAniminator(animationTrigger);

        // show AR marker (arrow)
    }

    public virtual void Hide ()
    {
        // hide AR marker (arrow)
    }
    public void PlayPartAniminator (string Trigger)
    {
        foreach(Animator animator in partAnimator)
        {
            animator.SetTrigger(Trigger);
        }
    }
}
