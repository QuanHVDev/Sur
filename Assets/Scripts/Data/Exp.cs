using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public bool IsCollected { get; private set; } = false;

    public void Collected() {
        IsCollected = true;
        gameObject.SetActive(false);
    }

    public void DoReset()
    {
        IsCollected = false;
        gameObject.SetActive(true);
    }
}
