using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text gemText;
    public TMP_Text starText;

    public Player player;

    void Update()
    {
        if (player == null || player.wallet == null) return;

        if (coinText) coinText.text = player.wallet.Coin.ToString();
        if (gemText) gemText.text = player.wallet.Gem.ToString();
        if (starText) starText.text = player.wallet.Star.ToString();
    }
}
