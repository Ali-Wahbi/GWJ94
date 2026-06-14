using Godot;
using GWJ94.scripts.ui;

namespace GWJ94.scripts.autoload.ui;

public partial class UiManager : CanvasLayer
{
	public static UiManager Instance { get; private set; }
	private UiData _uiData;
	private CoinPanel _coinPanel;
	private Control _trashPanel;

	public override void _Ready()
	{
		Instance = this;
		_uiData.OnCoinUpdate += UpdateCoinPanel;
		_uiData.OnTrashUpdate += UpdateTrashPanel;
		
		_coinPanel = GetNode<CoinPanel>("CoinPanel");
		_trashPanel = GetNode<Control>("TrashPanel");
	}

	private void UpdateCoinPanel(int value)
	{
		_coinPanel.UpdateCoinText(value);
	}

	private void UpdateTrashPanel(int current, int max)
	{
		
	}
	
	
}