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

        Debug.Log("Make me a sword please!");
        Debug.Log(Inventory);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            try
            {
                Debug.Log("Attempting to craft a sword:");
                var sword = _craftingTable.Craft<Sword>(this);
                Debug.Log("Sword Crafted!");
                Debug.Log(Inventory);
            }
            catch(CraftingException ex)
            {
                // Handle CraftingException here
                Debug.LogError(ex.Message);
            }
        }
    }
}
