using Godot;
using GWJ94.scenes.ui;

namespace GWJ94.scripts.autoload.ui;

public partial class ShopManager : Control
{
	public static ShopManager Instance {get; private set;}
	[Export] public Godot.Collections.Array<ShopItemData> Items = new();
	private UiData _uiData;
	[Export] Control _shopPanel;
	[Export] private Button _exitButton;
	
	public override void _Ready()
	{
		Instance = this;
		if (Instance is null)
		{
			GD.PrintErr("ShopManager not found");
		}
		_uiData = UiData.Instance;
		_exitButton.Pressed += ExitButtonPressed;
	}

	public override void _ExitTree()
	{
		_exitButton.Pressed -= ExitButtonPressed;
		
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public bool TryBuy(int index)
	{
		int i = index - 1;
		if (i < 0 || i >= Items.Count)
		{
			GD.PrintErr("TryBuy index out of range");
			GD.Print($"Index: {i}");
		}
		var item = Items[i];

		if (item is null)
		{
			return false;
		}

		if (!_uiData.TrySpendCoins(item.Cost))
		{
			return false;
		}
		
		GD.Print($"{item.Name} bought!");
		return true;
	}
	
	private void ExitButtonPressed()
	{
		_shopPanel.Visible = false;
	}
}