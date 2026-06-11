namespace Assignment_2B;
    /// <summary>
    /// A class to manage the items in the menu of the restaurant 
    /// </summary>
public class Item
{
    // Declaring fields and properties for item
    private string itemName;
    public string ItemName
    {
        get { return itemName; }
    }
    
    private double itemPrice;
    public double ItemPrice
    {
        get { return itemPrice; }
    }
    public int ItemQuantity{get;set;}

    /// <summary>
    /// Constructor for the item class
    /// </summary>
    /// <param name="itemName">The name of the item.</param>
    /// <param name="itemPrice">The price of the item.</param>

    public Item(string itemName, double itemPrice)
    {
        this.itemName = itemName;
        this.itemPrice = itemPrice;
        ItemQuantity = 1; // initial quantity is set to 1.
    }
}