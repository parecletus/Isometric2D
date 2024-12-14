using System;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected float statetimer;
    public AnimationClip anim;
    public Animator _animator;
    public virtual void Enter()
    {
        statetimer = 0;
        if (anim != null) _animator.Play(anim.name);
    }
    public virtual void Do()
    {
        statetimer += Time.deltaTime;
    }
    public virtual void Exit()
    {

    }
    public void Setup(Animator animator)
    {
        _animator = animator;
    }
}
