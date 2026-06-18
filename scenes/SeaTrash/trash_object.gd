extends RigidBody2D

@onready var collider: CollisionShape2D = $CollisionShape2D
@onready var sprite: Sprite2D = $Sprite2D
@onready var ripple: AnimatedSprite2D = $WaterRipple

@export_enum("Tire:0", "Bottle:4", "Barrell:5", "Blancks:9", "Plastic:10", "Book:14") var type: int
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	ripple.pause()
	ripple.hide()
	sprite.frame = type

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(_delta: float) -> void:
	if Input.is_action_just_pressed("ui_accept"):
		catch()
	
	move_and_collide(Vector2.ONE * 0.01)

func catch() -> void:
	sprite.hide()
	ripple.show()
	ripple.play("default")
	collider.disabled = true
	await ripple.animation_finished
	queue_free()