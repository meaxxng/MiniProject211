using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMiniProject : MonoBehaviour
{
    public CurrencyType requiredCurrency = CurrencyType.COIN;
    public int requiredAmount = 1;
    public bool isOpen = false;

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Wallet playerWallet = other.GetComponent<Wallet>();
        if (playerWallet != null)
        {
            Debug.Log("พบ Player, Coin ก่อน: " + playerWallet.Coin);

            if (playerWallet.Use(requiredCurrency, requiredAmount))
            {
                Debug.Log("จ่ายเงินสำเร็จ!");
                Open();
            }
            else
            {
                Debug.Log("เงินไม่พอ!");
            }

            Debug.Log("Coin หลังใช้: " + playerWallet.Coin);
        }
        else
        {
            Debug.LogWarning("Player ไม่มี Wallet component!");
        }
    }
}

    public void TryOpen(Wallet wallet)
    {
        if (isOpen || wallet == null) return;

        if (wallet.Use(requiredCurrency, requiredAmount))
        {
            Open();
            Debug.Log("เปิดประตูสำเร็จ! ใช้ " + requiredAmount + " " + requiredCurrency);
        }
        else
        {
            Debug.Log("เงินไม่พอ ต้องการ " + requiredAmount + " " + requiredCurrency);
        }
    }

    void Open()
    {
        isOpen = true;

        if (TryGetComponent<Renderer>(out var rend))
            rend.enabled = false;

        if (TryGetComponent<Collider>(out var col))
            col.enabled = false;
    }
}


