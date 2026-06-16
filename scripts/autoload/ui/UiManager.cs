using Godot;
using GWJ94.scenes.ui;
using GWJ94.scripts.ui;
using TrashPanel = GWJ94.scripts.ui.TrashPanel;

namespace GWJ94.scripts.autoload.ui;

public partial class UiManager : CanvasLayer
{
	private static UiManager _instance { get; set; }
	private UiData _uiData;
	private CoinPanel _coinPanel;
	private TrashPanel _trashPanel;
	[Export] private Control _shop;

	public override void _Ready()
	{
		_instance = this;
		if (_instance is null)
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

	public override void _ExitTree()
	{
		if (_uiData != null)
		{
			_uiData.OnCoinUpdate -= UpdateCoinPanel;
			_uiData.OnTrashUpdate -= UpdateTrashPanel;
		}
			
		if (_instance == this)
		{
			_instance = null;
		}
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