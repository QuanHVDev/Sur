using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Actor")]
public class ActorSO : ScriptableObject
{
    [SerializeField] private float hp;
    [SerializeField] private float dame;
    [SerializeField] private float speed;

    public float Hp => hp;
    public float Dame => dame;
    public float Speed => speed;
}
