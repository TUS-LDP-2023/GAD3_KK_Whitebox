using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ingriedient", menuName = "ObjectData/Items/Ingriedient Item")]

public class IngriedientData : ObjectData
{
    public void Awake()
    {
        typeofItem = TypeofItem.Ingriedent;
    }
}
