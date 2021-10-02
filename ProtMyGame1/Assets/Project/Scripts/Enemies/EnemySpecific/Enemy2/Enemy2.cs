using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    public Enemy2_IdleState idleState { get; private set; }

    public Enemy2_MoveState moveState { get; private set; }

    public Enemy2_PlayerDetectedState playerDetectedState { get; private set; }

    public Enemy2_MeleeAttackState meleeAttackState { get; private set; }

    public Enemy2_LookForPlayerState lookForPlayerState { get; private set; }

    public Enemy2_StunState stunState { get; private set; }
    
    public Enemy2_DeadState deadState { get; private set; }

    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_MeleeAttack meleeAttackStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_StunState stunStateData;
    [SerializeField] private D_DeadState deadStateData;


    [SerializeField] private Transform meleeAttackPosition;


    public override void Start()
    {
        base.Start();

        idleState = new Enemy2_IdleState(this, stateMachine, "idle", idleStateData, this);
        moveState = new Enemy2_MoveState(this, stateMachine, "move", moveStateData, this);
        playerDetectedState = new Enemy2_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        meleeAttackState = new Enemy2_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new Enemy2_LookForPlayerState(this, stateMachine, "looForPlayer", lookForPlayerStateData, this);
        stunState = new Enemy2_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new Enemy2_DeadState(this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(moveState);

    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }

        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            lookForPlayerState.SetTurnImmediately(true);
            stateMachine.ChangeState(lookForPlayerState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
