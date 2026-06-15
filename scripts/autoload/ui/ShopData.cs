using Godot;
using Godot.NativeInterop;

namespace GWJ94.scripts.autoload.ui;

public partial class ShopData : Node
{
	public ShopData Instance {get; private set;}
	[Export] public Godot.Collections.Array<ShopItemData> Items = new();
	override public void _Ready()
	{
		Instance = this;
		if (Instance is null)
		{
			GD.PrintErr("ShopManager not found");
		}
	}

	public void HandleShopping(int coins)
	{
		var items = Items;
		
		foreach (var item in items)
		{
			int cost = item.Cost;
			string name = item.Name;
			string description = item.Description;
		}
	}
}