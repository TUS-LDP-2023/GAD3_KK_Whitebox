using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics.Contracts;

public class ThrowPotion : MonoBehaviour
{
    [Header("Referencing")]
    public Transform playerCam;
    public Transform throwPos;
    public GameObject potionPrefab;
    public StarterAssetsInputs inputs;
    [Header("Throw Data")]
    public int totalThrows;
    public float cooldown;
    public bool isCrafting = false;
    public Image craftBar;
    public GameObject craftingUI;
    public float craftSpeed;
    public float craftProgress;
    [Header("Throwing Parameters")]
    public float throwForce;
    public float raiseForce;
    public bool readyToThrow;
    [Header("List of Potions")]
    public List<GameObject> potionList = new List<GameObject>(3);
    public int listPos;

    void Start()
    {
        readyToThrow = true;

        listPos = 0;

        craftBar.fillAmount = 0;
    }

    void Update()
    {
        if(inputs.throwP == true && readyToThrow == true && totalThrows > 0)
        {
            ThrowPotions();
            inputs.throwP = false;
        }

        if(inputs.Cycle == true)
        {
            inputs.Cycle = false;
            listPos++;
        }
        if(listPos >= 3)
        {
            listPos = 0;
        }

        Craft();
    }

    private void ThrowPotions()
    {
        readyToThrow = false;

        GameObject potion = Instantiate(potionList[listPos], throwPos.position, playerCam.rotation);

        Rigidbody potionRb = potion.GetComponent<Rigidbody>();

        Vector3 force = playerCam.transform.forward * throwForce + transform.up * raiseForce;

        potionRb.AddForce(force, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(Cooldown), cooldown);
    }

    public void Cooldown()
    {
        readyToThrow = true;
    }


    public void Craft()
    {
        if(inputs.craft == true && isCrafting == false)
        {
            StartCoroutine("CraftTime");
            craftingUI.SetActive(true);
        }
        if(inputs.craft == false)
        {
            StopCoroutine("CraftTime");
            isCrafting = false;
            craftingUI.SetActive(false);

        }
    }

    public IEnumerator CraftTime()
    {
        isCrafting = true;
        craftProgress = 0;

        while (craftProgress < 1)
        {
            craftProgress += Time.deltaTime / craftSpeed;
            craftBar.fillAmount = craftProgress;
            yield return null;
        }

        totalThrows++;
        isCrafting = false;
        craftBar.fillAmount = 0;
    }
}

