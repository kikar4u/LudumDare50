using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodState
{
    FROZEN,
    RAW,
    MEDIUM,
    WELLDONE,
    BURNED
}

[System.Serializable]
public class FoodParam {
    public FoodState m_FoodLevel;
    public int m_point;
}

[CreateAssetMenu(fileName = "New Food Parametter", menuName = "New Scriptable Object/New FoodParam")]
public class FoodParam_SO : ScriptableObject
{
    public List<FoodParam> param;
}
