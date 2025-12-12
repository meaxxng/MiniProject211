using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public CurrencyType rewardType = CurrencyType.GEM;
    public int rewardAmount = 1;
    public bool isOpened = false;


    // Called when player collides (we use manual call from Player) or via trigger
    public void OpenBox(Wallet wallet)
    {
        if (isOpened) return;
        isOpened = true;
        wallet.Add(rewardType, rewardAmount);
        // play VFX / sound here
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isOpened) return;
        if (other.TryGetComponent<Player>(out var player))
        {
            OpenBox(player.wallet);
        }
    }
}
