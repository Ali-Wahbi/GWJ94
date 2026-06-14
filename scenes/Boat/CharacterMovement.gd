extends CharacterBody2D

@onready var boatSprite: Sprite2D = $boatSprite
@export var movementSpeed: Vector2 = Vector2(300, 300)

var upOrLeft = -1
var downOrRight = 1
var animationFrame = 0
func _physics_process(delta: float) -> void:
	# Up => 45 degrees 1,-1
	# Down => 225 degrees -1,1
	# Left => 135 degrees -1,-1
	# Right => 315 degrees 1,1
	var inputY = Input.get_axis("Up", "Down")
	var inputX = Input.get_axis("Left", "Right")

	var directionX = 0.0
	var directionY = 0.0

	if inputY == upOrLeft:
		# Up
		directionX = 1
		directionY = -1
		animationFrame = 1
	elif inputY == downOrRight:
		# Down
		directionX = -1
		directionY = 1
		animationFrame = 2
	if inputX == upOrLeft:
		# Left
		directionX = -1
		directionY = -1
		animationFrame = 0
	elif inputX == downOrRight:
		# Right
		directionX = 1
		directionY = 1
		animationFrame = 3
			

	if directionY:
		velocity.y = directionY * movementSpeed.y
	else:
		velocity.y = move_toward(velocity.y, 0, movementSpeed.y)

	if directionX:
		velocity.x = directionX * movementSpeed.x
	else:
		velocity.x = move_toward(velocity.x, 0, movementSpeed.x)

	move_and_slide()
	setAnimationFrames()


func setAnimationFrames():
	boatSprite.frame = animationFrame
