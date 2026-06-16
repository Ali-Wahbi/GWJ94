using System;
using Godot;

namespace GWJ94.scripts.autoload.ui;

public partial class UiData : Node
{
	public static UiData Instance {get; private set;}
	public event Action<int> OnCoinUpdate;
	public event Action<int, int> OnTrashUpdate;
	public int Coins { get; private set; } = 500;
	public int CurrentTrash { get; private set; } 
	public int MaxTrash { get; private set; } 

	public override void _Ready()
	{
		Instance = this;
		if (Instance is null)
		{
			GD.PrintErr("UiData not found");
		}
	}
	
	public override void _ExitTree()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void InitializeCoins(int value)
	{
		if (value < 0)
		{
			return;
		}
		Coins = value;
	}

	public void InitializeTrash(int current, int capacity)
	{
		if (current < 0 || capacity < 0)
		{
			return;
		}
		MaxTrash = Mathf.Max(1, capacity);
		CurrentTrash = Mathf.Clamp(current, 0, MaxTrash);
	}

	public void CollectCoins(int value)
	{
		if (value < 0)
		{
			return;
		}
		Coins += value;
		OnCoinUpdate?.Invoke(Coins);
	}

	public bool TrySpendCoins(int cost)
	{
		if (Coins < cost)
		{
			return false;
		}
		Coins -= cost;
		OnCoinUpdate?.Invoke(Coins);
		return true;
	}

	public void CollectTrash(int value)
	{
		if (value < 0)
		{
			return;
		}
		CurrentTrash += value;
		CurrentTrash = Mathf.Clamp(CurrentTrash, 0, MaxTrash);
		OnTrashUpdate?.Invoke(CurrentTrash, MaxTrash);
	}
}