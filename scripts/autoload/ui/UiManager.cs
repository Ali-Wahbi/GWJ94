using Godot;
using GWJ94.scenes.ui;
using GWJ94.scripts.ui;

namespace GWJ94.scripts.autoload.ui;

public partial class UiManager : CanvasLayer
{
	public static UiManager Instance { get; private set; }
	private UiData _uiData;
	private CoinPanel _coinPanel;
	private TrashPanel _trashPanel;

	public override void _Ready()
	{
		Instance = this;
		if (Instance is null)
		{
			GD.PrintErr("UiManager not found");
			return;
		}
		
		_uiData = UiData.Instance;
		_uiData.OnCoinUpdate += UpdateCoinPanel;
		_uiData.OnTrashUpdate += UpdateTrashPanel;
		
		_coinPanel = GetNode<CoinPanel>("RootControl/CoinPanel");
		_trashPanel = GetNode<TrashPanel>("RootControl/TrashPanel");
	}

	private void UpdateCoinPanel(int value)
	{
		_coinPanel.UpdateCoinText(value);
	}

	private void UpdateTrashPanel(int current, int max)
	{
		_trashPanel.UpdateTrashText(current, max);
	}
	
	
}