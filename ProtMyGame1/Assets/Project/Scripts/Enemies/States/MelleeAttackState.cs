using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleeAttackState : AttackState
{
    protected D_MeleeAttack stateData;

    protected AttackDetails attackDetails;

    public MelleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        attackDetails.damageAmount = stateData.attackDamage;
        attackDetails.position = entity.aliveGO.transform.position;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        //Проверка повреждения игрока
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        //Поиск объектов для повреждения
        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.SendMessage("Damage", attackDetails);
        }
    }
}