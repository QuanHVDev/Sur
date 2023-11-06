using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public Action<Exp> OnCollectExp;
    private RaycastHit2D[] hits;
    void Update() {
        hits = Physics2D.CircleCastAll(transform.position, 1f, Vector3.zero);
        if (hits.Length > 0) {
            foreach (var hit in hits) {
                if (hit.transform.TryGetComponent(out Exp exp)) {
                    if (!exp.IsCollected) {
                        exp.Collected();
                        OnCollectExp?.Invoke(exp);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
