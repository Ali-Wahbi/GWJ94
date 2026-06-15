extends Node2D

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


func _process(_delta):
	if Input.is_action_just_pressed("ui_accept"):
		collectCoin(10)
	
	if Input.is_action_just_pressed("ui_accept") and Input.is_action_just_pressed("Right"):
		collectCoin(10)
	

func collectCoin(value: int) -> void:
	# UiData.CollectCoins(value)
	pass

func updateUI() -> void:
	pass # Replace with function body.
