using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharStats))]
public class CharacterCombat : MonoBehaviour
{
    CharStats myStats;
    private float attackCooldown = 0f;

    void Start ()
    {
        myStats = GetComponent<CharStats>();
    }

    void Update ()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack (CharStats targetStats)
    {
        float effectiveLevelPhysAtk = Mathf.Round(myStats.attack.GetValue() * myStats.prayerMultiplyer.GetValue() + 11);
        float effectiveLevelMagAtk = Mathf.Round(myStats.mage.GetValue() * myStats.prayerMultiplyer.GetValue() + 11);
        float effectiveLevelRangAtk = Mathf.Round(myStats.range.GetValue() * myStats.prayerMultiplyer.GetValue() + 11);
        float effectiveLevelStr = Mathf.Round(myStats.strength.GetValue() * myStats.prayerMultiplyer.GetValue() + 11);

        float equipmentBonusPhysAtk = Mathf.Round(myStats.attackBonus.GetValue());
        float equipmentBonusMagAtk = Mathf.Round(myStats.mageAttack.GetValue());
        float equipmentBonusRangAtk = Mathf.Round(myStats.mageDefense.GetValue());

        float equipmentBonusPhysStr = Mathf.Round(myStats.strengthBonus.GetValue());
        float equipmentBonusMagStr = Mathf.Round(myStats.mageStrength.GetValue());
        float equipmentBonusRangStr = Mathf.Round(myStats.rangeStrength.GetValue());

        float maxHitPhysStr = Mathf.Round(((float)0.5 + effectiveLevelStr) * ((equipmentBonusPhysStr +64)/640));
        float maxHitRangStr = Mathf.Round(((float)1.3 + (effectiveLevelRangAtk/10)) * ((equipmentBonusRangStr)/80) + ((effectiveLevelRangAtk * equipmentBonusRangStr)/640));
        float maxHitMagStr =  Mathf.Round(((float)0.5 + effectiveLevelMagAtk) * ((equipmentBonusMagStr +64)/640)); //magic max hit is actually based on the table of spells used - each spell has a base max hit. this is a substitute as it just uses the melee version. (magic might be a lot stronger than intended)

        float physAtkRoll = Mathf.Round((effectiveLevelPhysAtk * (equipmentBonusPhysAtk + 64))/640);
        float rangAtkRoll = Mathf.Round((effectiveLevelRangAtk * (equipmentBonusRangAtk + 64))/640);
        float magAtkRoll = Mathf.Round((effectiveLevelMagAtk * (equipmentBonusMagAtk + 64))/640);
        float actualHit;
        if (attackCooldown <= 0f)
        {
            //physical
            if (myStats.attackType.GetValue() == 1)
            {
                //pass in physical attributes
                actualHit = Mathf.Round(Random.value * maxHitPhysStr);
                targetStats.TakeDamage(physAtkRoll, myStats.attackType.GetValue(), actualHit);
                attackCooldown = 1f / myStats.attackSpeed.GetValue();
            }
            //magical
            else if (myStats.attackType.GetValue() == 2)
            {
                //pass in magic attributes
                actualHit = Random.value * maxHitMagStr;
                targetStats.TakeDamage(magAtkRoll,myStats.attackType.GetValue(), actualHit);
                attackCooldown = 1f / myStats.attackSpeed.GetValue();
            }
            //range
            else if (myStats.attackType.GetValue() == 3)
            {
                //pass in raged attributes
                actualHit = Random.value * maxHitRangStr;
                targetStats.TakeDamage(rangAtkRoll,myStats.attackType.GetValue(), actualHit);
                attackCooldown = 1f / myStats.attackSpeed.GetValue();
            }
        }
    }
}
