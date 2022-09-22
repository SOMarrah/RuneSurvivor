using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public int attackSpeed;
    public int attackRange;
    public int attackBonus;
    public int strengthBonus;
    public int defenseBonus;
    public int rangeStrength;
    public int mageStrength;
    public int mageAttack;
    public int mageDefense;
    public int prayerBonus;
    public int attackType; //1 is phys, 2 is mag, 3 is range
    //to do: attack styles
    //undead, slayer, void

    public override void Use()
    {
        base.Use();
        //equip the item
        EquipmentManager.instance.Equip(this);
        //remove it from the inventory
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Head, Cape, Amulet, Ammunition, Weapon, Chest, Shield, Legs, Gloves, Boots, Ring}
