using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Item : Identity
{
    private Collider _collider;
    protected Collider itemcollider
    {
        get
        {
            if (_collider == null)
            {
                _collider = GetComponent<Collider>();
                _collider.isTrigger = true;
            }
            return _collider;
        }
    }

    // 🟢 Constructor ว่าง (จำเป็นสำหรับ Unity)
    public Item() { }

    // 🟦 Copy Constructor → อันนี้จะถูกใช้ตอนที่ CollectableItem เรียก base(item)
    public Item(Item item)
    {
        this.Name = item.Name;   // ถ้ามี property อื่นก็ใส่เพิ่มได้
    }

    public override void SetUP()
    {
        base.SetUP();
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollect(player);
        }
    }

    public virtual void OnCollect(Player player)
    {
        Debug.Log($"Collected {Name}");
    }

    public virtual void Use(Player player)
    {
        Debug.Log($"Using {Name}");
    }
}
