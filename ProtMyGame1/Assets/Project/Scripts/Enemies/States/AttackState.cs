using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected Transform attackPosition;

    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;

    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();
        entity.animToStateMachine.attackState = this;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public virtual void TriggerAttack()
    {

    }

    //«авершение атаки дл€ перехода в другие состо€ни€
    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
