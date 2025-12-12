using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRespawn : MonoBehaviour
{
    public CurrencyType currencyType = CurrencyType.GEM;
    public int costAmount = 1;


    // Try to charge player gems to respawn; returns true if charged
    public bool CanUseSpecialRespawn(Wallet wallet)
    {
        if (wallet == null) return false;
        return wallet.Use(currencyType, costAmount);
    }
}