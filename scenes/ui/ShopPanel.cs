using Godot;
using GWJ94.scripts.autoload.ui;

namespace GWJ94.scenes.ui;

public partial class ShopPanel : Control
{
	[Export] public int ItemIndex;

	public int GetIndex()
	{
		return ItemIndex;
	}
}