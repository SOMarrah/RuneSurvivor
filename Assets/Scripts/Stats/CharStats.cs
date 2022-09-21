using UnityEngine;

public class CharStats : MonoBehaviour
{

    public Stat attackSpeed;
    public Stat attackRange;
    public Stat attackBonus;
    public Stat strengthBonus;
    public Stat defenseBonus;
    public Stat rangeStrength;
    public Stat mageStrength;
    public Stat mageDefense;
    public Stat prayerBonus;
    
    public Stat prayerMultiplyer;
    public Stat attack;
    public Stat strength;
    public Stat defense;
    public Stat range;
    public Stat mage;
    public Stat prayer;
    public Stat hitpoints;

    public int currentHealth {get; private set; }
    public float chance;
    void Awake ()
    {
        currentHealth = hitpoints.GetValue();
    }
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(7, "physical", 10);
        }
    }

    public void TakeDamage (int attackRoll, string damageType,  int damageRoll)
    {
        //osrs attack roll prayer adjustment +attack style (3 for now) + 8 + void -- later...prayer should default to 1x
        float effectiveLevelPhys = Mathf.Round(defense.GetValue() * prayerMultiplyer.GetValue() + 11);
        float effectiveLevelMag = Mathf.Round(mage.GetValue() * prayerMultiplyer.GetValue() + 11);
        float equipmentBonusPhys = Mathf.Round(defenseBonus.GetValue());
        float equipmentBonusMag = Mathf.Round(mageDefense.GetValue());

        Debug.Log("effectiveLevelPhys: " + effectiveLevelPhys + " equipment bonus phys: " + equipmentBonusPhys);

        if( damageType == "physical")
        {
            float physDefRoll = Mathf.Round((effectiveLevelPhys * (equipmentBonusPhys + 64))/640);
            Debug.Log("physDefRoll: " + physDefRoll);
            Debug.Log("Attack roll: " + attackRoll);
            if( attackRoll > physDefRoll)
            {
                chance = 1 - ((physDefRoll +2) / (2 * (attackRoll + 1)));
               if(Random.value > chance)
               {
                currentHealth -= Mathf.Clamp(damageRoll, 0, int.MaxValue);
                Debug.Log(transform.name + " takes " + damageRoll);
               }else
               {
                Debug.Log(transform.name + " dodged the attack!");
               }
            }
            else if( attackRoll <= physDefRoll)
            {
                chance = 1-(attackRoll/(2*physDefRoll));
                Debug.Log("chance attack is less than def: " + chance);
                if(Random.value > chance)
                {
                    currentHealth -= Mathf.Clamp(damageRoll, 0, int.MaxValue);
                    Debug.Log(transform.name + " takes " + damageRoll);
                }else
               {
                Debug.Log(transform.name + " dodged the attack!");
               }
            }

        }
        else if (damageType == "magic")
        {
            float magDefRoll = effectiveLevelMag * (equipmentBonusMag + 64);
            if( attackRoll > magDefRoll)
            {
               chance = 1-(magDefRoll +2 / (2 * attackRoll + 1));
               if(Random.value < chance)
               {
                currentHealth -= damageRoll;
                Debug.Log(transform.name + " takes " + damageRoll);
               }else
               {
                Debug.Log(transform.name + " dodged the attack!");
               }
            }
            else if( attackRoll <= magDefRoll)
            {
                chance = 1-(attackRoll/(2*magDefRoll));
                if(Random.value < chance)
               {
                currentHealth -= damageRoll;
                Debug.Log(transform.name + " takes " + damageRoll);
               }else
               {
                Debug.Log(transform.name + " dodged the attack!");
               }
            }
        }
        


        if(currentHealth <= 0)
        {
            Die();

        }
    }

    public virtual void Die ()
    {
        //die in some way
        //meant to be overwritten
        Debug.Log(transform.name + " died.");
    }
}
