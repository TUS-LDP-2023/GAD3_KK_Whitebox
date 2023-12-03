using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Item", menuName = "ObjectData/Items/Heal Item")]
public class InstantUseData : ObjectData
{
    public int amountToHeal;
    public void Awake()
    {
        typeofItem = TypeofItem.InstantUse;
    }
}
