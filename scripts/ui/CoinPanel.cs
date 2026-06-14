using Godot;

namespace GWJ94.scripts.ui;

public partial class CoinPanel : Control
{
	private Label _coinAmountLabel;
	public override void _Ready()
	{
		_coinAmountLabel = GetNode<Label>("CoinAmount");
	}

	public void UpdateCoinText(int value)
	{
		_coinAmountLabel.Text = value.ToString();
	}
	
	
}