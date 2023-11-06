using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Actor")]
public class ActorSO : ScriptableObject
{
    [SerializeField] private float hp;
    [SerializeField] private float dame;
    [SerializeField] private float speed;
    [SerializeField] private float delayAttack;
    [SerializeField] private float attackRange;


    public float Hp => hp;
    public float Dame => dame;
    public float Speed => speed;
    public float DelayAttack => delayAttack;
    public float AttackRange => attackRange;
}
