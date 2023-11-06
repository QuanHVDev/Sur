using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : ActorBase
{
    [SerializeField] private AIDestinationSetter aiDestinationSetter;

    public void Init(Transform target) {
        aiDestinationSetter.target = target;
    }
}
