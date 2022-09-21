using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            attackSpeed.AddModifier(newItem.attackSpeed);
            attackRange.AddModifier(newItem.attackRange);
            attackBonus.AddModifier(newItem.attackBonus);
            strengthBonus.AddModifier(newItem.strengthBonus);
            defenseBonus.AddModifier(newItem.defenseBonus);
            rangeStrength.AddModifier(newItem.rangeStrength);
            mageStrength.AddModifier(newItem.mageStrength);
            mageDefense.AddModifier(newItem.mageDefense);
            prayerBonus.AddModifier(newItem.prayerBonus);

        }

        if(oldItem != null)
        {
            attackSpeed.RemoveModifier(oldItem.attackSpeed);
            attackRange.RemoveModifier(oldItem.attackRange);
            attackBonus.RemoveModifier(oldItem.attackBonus);
            strengthBonus.RemoveModifier(oldItem.strengthBonus);
            defenseBonus.RemoveModifier(oldItem.defenseBonus);
            rangeStrength.RemoveModifier(oldItem.rangeStrength);
            mageStrength.RemoveModifier(oldItem.mageStrength);
            mageDefense.RemoveModifier(oldItem.mageDefense);
            prayerBonus.RemoveModifier(oldItem.prayerBonus);
        }
        
    }
}


