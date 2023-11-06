using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private SimpleTouchController leftController;


    public Vector3 TouchDir => leftController.GetTouchPosition;
}
