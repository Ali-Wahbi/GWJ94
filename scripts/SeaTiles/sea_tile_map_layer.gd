extends TileMapLayer

## The Grid size of the sea. 
## must be an even number as the tiles rotate around the origin point
@export var gridSize: Vector2i

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	makeTiles()


var sourceID = 2
var atlasCoords = Vector2i(0, 0)
var alternative = 0
func makeTiles():
	# clear all existing tiles
	clear()
	var halfX = int(gridSize.x / 2.0)
	var halfY = int(gridSize.y / 2.0)
	for xCoords in range(halfX):
		for yCoords in range(halfY):
			var cellCoordinates = Vector2(xCoords, yCoords)
			set_cell(cellCoordinates, sourceID, atlasCoords, alternative)