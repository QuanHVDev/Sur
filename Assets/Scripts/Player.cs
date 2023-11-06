using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : ActorBase
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private Collector collector;
    public override void Init(ActorSO actorSo)
    {
        base.Init(actorSo);
        collector = gameObject.AddComponent<Collector>();
        collector.OnCollectExp += Collector_OnCollectExp;
    }

    private void Collector_OnCollectExp(Exp exp) {
        Debug.Log("Collected");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
        if (GameManager.Instance.GetTouchDir() != Vector3.zero)
        {
            _rigidbody.MovePosition(transform.position +
                                    (new Vector3(0, 1, 0) * GameManager.Instance.GetTouchDir().y * Time.deltaTime * Speed) +
                                    (transform.right * GameManager.Instance.GetTouchDir().x * Time.deltaTime * Speed));
        }
    }

    public override void Dead() {
        IsDead = true;
    }
}