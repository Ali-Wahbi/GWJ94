using Godot;

namespace GWJ94.scripts.ui;

public partial class TrashPanel : Control
{
	private Label _trashAmountLabel; 
	public override void _Ready()
	{
		_trashAmountLabel = GetNode<Label>("TrashAmount");
	}

	public void UpdateTrashText(int current, int max)
	{
		var currentTrash = current.ToString();
		var maxTrash = max.ToString();
		
		_trashAmountLabel.Text = $"{currentTrash} / {maxTrash}";
	}
}