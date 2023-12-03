using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeofItem
{
    Ingriedent,
    InstantUse
}
public class ObjectData : ScriptableObject
{
    public string nameOfItem;
    public Sprite icon;
    public int quantity;
    public TypeofItem typeofItem;
}
