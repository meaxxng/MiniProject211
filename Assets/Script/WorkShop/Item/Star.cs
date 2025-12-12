using UnityEngine;

public class Star : Item
{
    public int amount = 1;
    public AudioClip SoundStar;

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        // เพิ่มค่า Star
        player.wallet.Add(CurrencyType.STAR, amount);

        // เล่นเสียงถ้ามี
        if (SoundStar != null)
            AudioSource.PlayClipAtPoint(SoundStar, transform.position);

        // ลบ Star หลังเก็บ
        Destroy(gameObject);
    }
}
