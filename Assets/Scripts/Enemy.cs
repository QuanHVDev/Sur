using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : ActorBase
{
    [SerializeField] private AIPath aiPath;
    [SerializeField] private AIDestinationSetter aiDestinationSetter;

    public override void Init(ActorSO actorSo)
    {
        base.Init(actorSo);
        aiPath.maxSpeed = Speed;
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

    public override void Dead() {
        aiDestinationSetter.target = transform;
    }

    public AIPath AiPath =>  aiPath;
}
