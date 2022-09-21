// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Coins : MonoBehaviour
// {
//     public int coinValue;
//     void OnTriggerEnter(Collider other){
//         PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
//         Debug.Log("playerInventory?:", playerInventory);
//         if(playerInventory != null){
//             Debug.Log("Coin on trigger enter?");
//             playerInventory.CoinCollected( coinValue);
//             gameObject.SetActive(false);
//         }
//     }

// }
