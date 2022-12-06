using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObject : BaseObject, IAnimationObject
{
    public override void OnClicked(InteractHand interactHand)
    {
        PlayAnimation();
    }

    public virtual void PlayAnimation(){}
}
