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
    public int mageBonus;
    public int mageDefense;
    public int prayerBonus;
    //to do: attack styles
    //undead, slayer, void

}

public enum EquipmentSlot { Head, Cape, Amulet, Ammunition, Weapon, Chest, Shield, Legs, Gloves, Boots, Ring}
