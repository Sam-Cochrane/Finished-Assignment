using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class BasePassive : MonoBehaviour
{
    public float baseCastTime;
    public float castTime;
    public float baseLevel;
    public float level;
    public float maxLevel;
    public float timeUntilNextCast;
    public Sprite icon;

    public abstract Type abilityStart();
    public abstract Type abilityUpdate();
}
