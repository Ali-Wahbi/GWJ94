extends Node2D

var currentCoins: int = 100

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.

func collectCoin(value: int) -> void:
	currentCoins += value

func consumeCoin(value: int) -> void:
	currentCoins -= value

func getCurrentCoins() -> int:
	return currentCoins

func updateUI() -> void:
	pass # Replace with function body.