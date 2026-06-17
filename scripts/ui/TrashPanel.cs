using Godot;

namespace GWJ94.scripts.ui;

public partial class TrashPanel : Control
{
	[Export] Label _trashAmountLabel; 
	
	public void UpdateTrashText(int current, int max)
	{
		var currentTrash = current.ToString();
		var maxTrash = max.ToString();
		
		_trashAmountLabel.Text = $"{currentTrash}/{maxTrash}";
	}
}