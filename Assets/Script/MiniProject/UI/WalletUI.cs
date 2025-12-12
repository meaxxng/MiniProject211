using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    public Wallet wallet;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gemText;
    public TextMeshProUGUI starText;

    void Update()
    {
        coinText.text = wallet.Coin.ToString();
        gemText.text = wallet.Gem.ToString();
        starText.text = wallet.Star.ToString();
    }
}
