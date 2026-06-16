extends CharacterBody2D

@onready var boatSprite: Sprite2D = $boatSprite
@onready var collider: CollisionShape2D = $CollisionShape2D

@export var movementSpeed: Vector2 = Vector2(300, 300)

var upOrLeft = -1
var downOrRight = 1
var animationFrame = 1
func _physics_process(_delta: float) -> void:
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
		collider.rotation_degrees = 52.0
	elif inputY == downOrRight:
		# Down
		directionX = -1
		directionY = 1
		animationFrame = 2
		collider.rotation_degrees = 48.0
	if inputX == upOrLeft:
		# Left
		directionX = -1
		directionY = -1
		animationFrame = 0
		collider.rotation_degrees = -52.0
	elif inputX == downOrRight:
		# Right
		directionX = 1
		directionY = 1
		animationFrame = 3
		collider.rotation_degrees = -48.0
			

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
