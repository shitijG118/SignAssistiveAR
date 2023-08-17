using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    

    public void PlayAnimationLearn()
    {
        // Trigger the animation by setting the corresponding parameter in the Animator
        animator.SetBool("Fun",false);
        animator.SetBool("Learn",true);
    }
     public void PlayAnimationFun()
    {
        // Trigger the animation by setting the corresponding parameter in the Animator
        animator.SetBool("Learn",false);
        animator.SetBool("Fun",true);
    }
}

