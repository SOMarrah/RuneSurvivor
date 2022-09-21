using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharStats myStats;

    void Start () 
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharStats>();
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
        //Attack the enemy
    }
}
