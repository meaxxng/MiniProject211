using UnityEngine;

public class Coin : Item
{
    public int ScoreValue = 10;      // coin value
    public AudioClip SoundCoin;

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        // เพิ่มเงิน coin
        player.wallet.Add(CurrencyType.COIN, ScoreValue);

        // เล่นเสียง
        if (SoundCoin != null)
            AudioSource.PlayClipAtPoint(SoundCoin, transform.position);

        // ลบ coin
        Destroy(gameObject);
    }
}
