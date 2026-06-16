using Godot;
using GWJ94.scenes.ui;

namespace GWJ94.scripts.autoload.ui;

public partial class ShopManager : Control
{
	public ShopManager Instance {get; private set;}
	[Export] public Godot.Collections.Array<ShopItemData> Items = new();
	private UiData _uiData;
	private TextureButton _buyButton;
	private UiManager _uiManager;
	override public void _Ready()
	{
		Instance = this;
		if (Instance is null)
		{
			GD.PrintErr("ShopManager not found");
		}
		_uiData = UiData.Instance;
		Visible = false;
	}

	public void TryBuy(ShopItemData item)
	{
		foreach (var i in Items)
		{
			//if index is equal, hide
		}
	}
}