extends RigidBody2D

@onready var collider: CollisionShape2D = $CollisionShape2D
@onready var sprite: Sprite2D = $Sprite2D
@onready var ripple: AnimatedSprite2D = $WaterRipple

## Type of trash object. based on frames in objects sheet.
@export_enum("Tire:0", "Bottle:4", "Barrell:5", "Blancks:9", "Plastic:10", "Book:14") var type: int

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	ripple.pause()
	ripple.hide()
	sprite.frame = type

## The Speed to move the object when colliding
@export var moveSpeed: float = 0.5
## The Speed to stop the object after colliding
@export var stopSpeed: float = 0.5
# the object that is colliding with this object
var collidingObject: KinematicCollision2D
# the direction to move in when colliding
var moveDirection: Vector2 = Vector2.ZERO

func _physics_process(delta: float) -> void:
	# for testing, remove later
	if Input.is_action_just_pressed("ui_accept"):
		catch()
	
	collidingObject = move_and_collide(moveDirection * moveSpeed)
	moveDirection = moveDirection.move_toward(Vector2.ZERO, delta * stopSpeed)
	handleCollision()

func catch() -> void:
	sprite.hide()
	ripple.show()
	ripple.play("default")
	collider.disabled = true
	await ripple.animation_finished
	call_deferred("queue_free")

func handleCollision() -> void:
	if collidingObject:
		# Get the normal vector of the collision. This vector points away from the collision surface.
		var collision_normal = collidingObject.get_normal()
		# Set the moveDirection to this normal vector to push the object away from the collision.
		moveDirection = collision_normal