using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Level")]
public class LevelSO : ScriptableObject {
    public int duringLevel;
    public List<StepLevel> Steps;
}

[Serializable]
public class StepLevel
{
    public int TimeSpawn;
    public List<InfoStep> InfoSteps;
}

[Serializable]
public class InfoStep
{
    public ActorSO info;
    public Enemy prefab;
}
