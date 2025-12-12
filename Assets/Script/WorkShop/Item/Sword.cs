using UnityEngine;

public class Sword : Item
{
    public int Damage = 25;

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        // ปิด Collider ไม่ให้ชนอีก
        itemcollider.enabled = false;

        // วางไว้ที่มือขวา
        transform.parent = player.RightHand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(90, 0, 0);

        // เพิ่มพลังโจมตี
        player.Damage += Damage;

        Debug.Log("Sword collected. Player damage increased by " + Damage);
    }
}
