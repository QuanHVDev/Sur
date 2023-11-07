using System;
using System.Collections;
using Pathfinding;
using UnityEngine;

public class Enemy : ActorBase
{
    [SerializeField] private AIPath aiPath;
    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private LayerMask targetMask;

    public override void Init(ActorSO actorSo)
    {
        base.Init(actorSo);
        aiPath.maxSpeed = Speed;
    }

    protected override void Update() {
        base.Update();
        if (IsCanAttack)
        {
            var hits = Physics2D.CircleCastAll(transform.position, AttackRange, Vector2.zero, AttackRange, targetMask);
            if (hits.Length > 0) {
                foreach (var hit in hits) {
                    if (hit.transform.TryGetComponent(out ActorBase actor) && !actor.IsDead) {
                        AttackTarget(actor);
                        break;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    public void SetTarget(Transform target) {
        aiDestinationSetter.target = target;
    }

    public void SetCanMove(bool isCanMove) {
        aiPath.canMove = isCanMove;
    }

    private IEnumerator SetSpeedAsync(float speed, float duringTime) {
        float currentSpeed = aiPath.maxSpeed;
        aiPath.maxSpeed = speed;
        yield return new WaitForSeconds(duringTime);
        aiPath.maxSpeed = currentSpeed;
    }
    
    [ContextMenu("DEAD")]
    public override void Dead() {
        base.Dead();
        aiDestinationSetter.target = transform;
        gameObject.SetActive(false);
    }

    public AIPath AiPath =>  aiPath;
}
