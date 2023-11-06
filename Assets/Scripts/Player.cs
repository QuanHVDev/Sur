using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorBase
{
    [SerializeField] private Rigidbody2D _rigidbody;
    public float speedMovements = 5f;
    

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetTouchDir() != Vector3.zero)
        {
            _rigidbody.MovePosition(transform.position +
                                    (new Vector3(0, 1, 0) * GameManager.Instance.GetTouchDir().y * Time.deltaTime * speedMovements) +
                                    (transform.right * GameManager.Instance.GetTouchDir().x * Time.deltaTime * speedMovements));
        }
    }
}