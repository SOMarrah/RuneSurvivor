using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Signleton
   public static EquipmentManager instance;

   void Awake ()
   {
        instance = this;
   }
   #endregion

   Equipment[] currentEquipment;

   void Start ()
   {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
   }

   public void Equip (Equipment newItem)
   {
        int slotIndex = (int)newItem.equipSlot;

        currentEquipment[slotIndex] = newItem;
   }
}
