using Godot;

namespace GWJ94.scripts.ui;

public partial class CoinPanel : Control
{
	[Export] private Label _coinAmountLabel;
	
	public void UpdateCoinText(int value)
	{
		_coinAmountLabel.Text = value.ToString();
	}
	
	
}