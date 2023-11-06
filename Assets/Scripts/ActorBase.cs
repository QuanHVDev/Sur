using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBase : MonoBehaviour
{
    public bool IsDead = false; // { get; private set; }
    public float Hp { get; protected set; }
    public float Dame { get; protected set; }
    public float Speed { get; protected set; }

    public virtual void Init(ActorSO actorSo) {
        Hp = actorSo.Hp;
        Dame = actorSo.Dame;
        Speed = actorSo.Speed;
    }

    public virtual void Dead() { }
}