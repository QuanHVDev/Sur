using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBase : MonoBehaviour
{
    public Action OnDead;
    
    
    public bool IsDead = false; // { get; private set; }
    public float Hp { get; protected set; }
    public float Dame { get; protected set; }
    public float Speed { get; protected set; }
    public float DelayAttack { get; protected set; }
    public float AttackRange { get; protected set; }
    
    public bool IsCanAttack = false; // { get; private set; }
    

    public virtual void Init(ActorSO actorSo) {
        Hp = actorSo.Hp;
        Dame = actorSo.Dame;
        Speed = actorSo.Speed;
        DelayAttack = actorSo.DelayAttack;
        AttackRange = actorSo.AttackRange;
        
        lastTimeAttack = Time.time;
        IsCanAttack = true;
        IsDead = false;
    }
    
    protected virtual void Update() {
        if (IsDead) return;
    }

    private float lastTimeAttack = 0;
    public virtual void AttackTarget(ActorBase actor) {
        if (Time.time > lastTimeAttack + DelayAttack) {
            lastTimeAttack = Time.time;
            actor.TakeDame(Dame);
        }
    }
    
    public virtual void TakeDame(float dame) {
        Hp -= dame;
        if (Hp <= 0) {
            Hp = 0;
            Dead();
        }
    }

    public virtual void Dead() {
        IsDead = true;
        Debug.Log($"{gameObject.name} Dead");
        OnDead?.Invoke();
    }
}