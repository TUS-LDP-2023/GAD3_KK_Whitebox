using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows;
using StarterAssets;
using UnityEngine.SceneManagement;

public class InventoryUIDisplay : MonoBehaviour
{
    [Header("Inventory Slot Display")]
    public Image slot;
    public TMP_Text text;
    public Inventory inventory;
    public int invPos = 0;

    [Header("Potion Slot Display")]
    public ThrowPotion potionScript;
    public TMP_Text equipText;
    [Header("Health Display")]
    public TMP_Text healthtext;
    public Health health;
    [Space]
    public StarterAssetsInputs inputs;
    [Header("Scene Announcer")]
    public TMP_Text sceneText;

    private void Start()
    {
        sceneText.enabled = true;
        sceneText.text = SceneManager.GetActiveScene().name;
        Invoke(nameof(HideText), 3);
    }

    public void HideText()
    {
        sceneText.enabled = false;
    }
    private void Update()
    {
        if(inventory.InventorySlot.Count > 0)
        {
            slot.enabled = true;
            text.enabled = true;

            InventorySlot slotDis = inventory.InventorySlot[invPos];

            slot.sprite = slotDis.item.icon;

            text.text = slotDis.item.quantity.ToString();

        } else
        {
            slot.enabled = false;
            text.enabled = false;
        }

        if (inputs.InvCycle == true)
        {
            inputs.InvCycle = false;
            invPos++;
        }
        if(inventory.InventorySlot.Count != 0)
        {
        if ((invPos / inventory.InventorySlot.Count) == 1)
        {
            invPos = 0;
        }
        }


        healthtext.text = health.currentHealth.ToString();

        equipText.text = potionScript.totalThrows.ToString();
    }
}
