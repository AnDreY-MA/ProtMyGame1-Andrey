using UnityEngine;

public class Enemy1_PlayerDetectedState : PlayerDetectedState
{
    private Enemy1 enemy;

    public Enemy1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }

        else if (performLongRangeAction)
        {
            //enemy.idleState.SefFlipAfterIdle(false);
            stateMachine.ChangeState(enemy.chargeState);
        }

        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }

        else if (!isDetectedLedge)
        {
            entity.Flip();
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}