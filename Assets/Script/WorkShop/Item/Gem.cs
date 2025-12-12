using UnityEngine;

public class Gem : Item
{
    public int amount = 1;
    public AudioClip SoundGem;

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        // เพิ่ม gem
        player.wallet.Add(CurrencyType.GEM, amount);

        if (SoundGem != null)
            AudioSource.PlayClipAtPoint(SoundGem, transform.position);

        Destroy(gameObject);
    }
}
