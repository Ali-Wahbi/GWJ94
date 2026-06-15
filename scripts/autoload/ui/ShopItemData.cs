using Godot;

namespace GWJ94.scripts.autoload.ui;

[GlobalClass]
public partial class ShopItemData : Resource
{
	[Export] public int Cost {get; set;}
	[Export] public string Name {get; set;}
	[Export] public string Description {get; set;}
}