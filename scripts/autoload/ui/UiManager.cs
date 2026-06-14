using Godot;

namespace GWJ94.scripts.autoload.ui;

public partial class UiManager : CanvasLayer
{
	public static UiManager Instance { get; private set; }
	private UiData _uiData;
	private Control _coinPanel;
	private Control _trashPanel;

	public override void _Ready()
	{
		Instance = this;
	}
	
	
}