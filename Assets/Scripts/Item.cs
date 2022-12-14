using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public virtual void Use()
    {
        //use
        //something might happen
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}
