using UnityEngine;

public class Wallet : MonoBehaviour
{
    [Header("Currency")]
    [SerializeField] private int coin = 0;
    [SerializeField] private int gem = 0;
    [SerializeField] private int star = 0;

    // Getter สำหรับ UI
    public int Coin => coin;
    public int Gem => gem;
    public int Star => star;

    // ============================
    // ADD CURRENCY
    // ============================
    public void Add(CurrencyType type, int amount)
    {
        if (amount <= 0) return;

        switch (type)
        {
            case CurrencyType.COIN:
                coin += amount;
                break;

            case CurrencyType.GEM:
                gem += amount;
                break;

            case CurrencyType.STAR:
                star += amount;
                break;
        }

        Debug.Log($"Add {amount} {type}.  Now: Coin={coin}, Gem={gem}, Star={star}");
    }

    // ============================
    // USE CURRENCY
    // ============================
    public bool Use(CurrencyType type, int amount)
    {
        if (amount <= 0) return true;

        if (!HasEnough(type, amount))
            return false;

        switch (type)
        {
            case CurrencyType.COIN:
                coin -= amount;
                break;

            case CurrencyType.GEM:
                gem -= amount;
                break;

            case CurrencyType.STAR:
                star -= amount;
                break;
        }

        Debug.Log($"Use {amount} {type}. Now: Coin={coin}, Gem={gem}, Star={star}");
        return true;
    }

    // ============================
    // CHECK IF ENOUGH
    // ============================
    public bool HasEnough(CurrencyType type, int amount)
    {
        if (amount <= 0) return true;

        switch (type)
        {
            case CurrencyType.COIN: return coin >= amount;
            case CurrencyType.GEM: return gem >= amount;
            case CurrencyType.STAR: return star >= amount;
        }

        return false;
    }

    public void SetCurrency(int coin, int gem, int star)
    {
        this.coin = coin;
        this.gem = gem;
        this.star = star;
    }
}
