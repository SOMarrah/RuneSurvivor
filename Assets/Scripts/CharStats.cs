using UnityEngine;

public class CharStats : MonoBehaviour
{
   public Stat attack;
   public Stat strength;
   public Stat defense;
   public Stat range;
   public Stat mage;
   public Stat prayer;
   public int hitpoints = 10;


   public int currentHitpoints {get; private set;}


   void Awake ()
   {
    currentHitpoints = hitpoints;
   }
   void Update()
   {
    if(Input.GetKeyDown(KeyCode.T))
    {
        TakeDamage(10);
    }
   }



   public void TakeDamage (int damage)
   {
    damage -= defense.GetValue();
    damage = Mathf.Clamp(damage, 0 , int.MaxValue);
    currentHitpoints -= damage;
    Debug.Log(transform.name + " takes " + damage + " damage.");
    if (currentHitpoints <= 0)
    {
        Die();
    }
   }

   public virtual void Die ()
   {
    //die in some way
    Debug.Log(transform.name + " died.");
   }
}
