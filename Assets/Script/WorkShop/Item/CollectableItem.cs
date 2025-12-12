using UnityEngine;

public class CollectableItem : Item
{
    public int value = 10;

    // ✅ Unity จำเป็นต้องมี constructor ว่าง
    public CollectableItem() { }

    // 🟦 copy constructor (ใช้ตอนสร้าง item ในระบบ inventory)
    public CollectableItem(CollectableItem item) : base(item)
    {
        value = item.value;
    }

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        // ส่งตัว object นี้ให้ player เก็บ
        player.AddItem(this);

        // ปิด object หลังเก็บ
        gameObject.SetActive(false);
    }
}

