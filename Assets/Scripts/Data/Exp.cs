using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour, IInteract
{
    public float AmountExp { get; private set; }
    public bool IsCollected { get; private set; } = false;
    

    public void DoReset()
    {
        IsCollected = false;
        gameObject.SetActive(true);
    }

    public void Interact()
    {
        IsCollected = true;
        gameObject.SetActive(false);
    }
}
