using System;
using UnityEngine;

public class Player : MonoBehaviour, ICraftingSource
{
    public Inventory Inventory { get; private set; } = new Inventory();

    private CraftingTable _craftingTable { get; set; }
    
    void Start()
    {
        _craftingTable = GameObject
            .FindGameObjectWithTag("CraftingTable")
            .GetComponent<CraftingTable>();
            
        Inventory.Add<Wood>(10);
        Inventory.Add<Steel>(5);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            try
            {

                Debug.Log("Make me a sword please!");
                Debug.Log(Inventory);
                
                var sword = _craftingTable.Craft<Sword>(this);

                Debug.Log(Inventory);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }
    }
}
