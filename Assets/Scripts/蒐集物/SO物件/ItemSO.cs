using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class ItemSO : ScriptableObject
{
    public abstract void CollectEffect();
}
