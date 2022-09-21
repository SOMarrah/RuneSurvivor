using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;
    void Awake ()
    {
        instance = this;
    }
    #endregion
    //if spawning in the player make sure to point/update this to point to that player character
    public GameObject player;
}
