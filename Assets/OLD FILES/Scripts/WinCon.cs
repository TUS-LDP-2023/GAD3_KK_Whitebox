using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinCon : MonoBehaviour
{

    public GameObject winText;
    public GameObject boss;

    private void Update()
    {
        if(boss.transform.childCount == 0)
        {
            winText.SetActive(true);
        }
    }

}
