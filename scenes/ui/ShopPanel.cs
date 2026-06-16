using Godot;
using GWJ94.scripts.autoload.ui;

namespace GWJ94.scenes.ui;

public partial class ShopPanel : Control
{
	[Export] public int ItemIndex;
	private TextureButton _buyButton;

	public override void _Ready()
	{
		_buyButton = GetNode<TextureButton>("Background/MarginContainer/HBoxContainer/BuyButton");
		_buyButton.Pressed += OnButtonPressed;
	}
	
	public override void _ExitTree()
	{
		if (_buyButton != null)
		{
			_buyButton.Pressed -= OnButtonPressed;
		}
	}

	public int GetIndex()
	{
		return ItemIndex;
	}

	private void OnButtonPressed()
	{
		if (ShopManager.Instance.TryBuy(ItemIndex))
		{
			_buyButton.Disabled = true;
		}
	}
}