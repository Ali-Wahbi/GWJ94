extends TileMapLayer

## The Grid size of the sea. 
## must be an even number as the tiles rotate around the origin point
@export var gridSize: Vector2i

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	makeTiles()
	makeRocksEdge()


var sourceID = 2
var atlasCoords = Vector2i(0, 0)
var alternative = 0
func makeTiles():
	# clear all existing tiles
	clear()
	var halfX = int(gridSize.x / 2.0)
	var halfY = int(gridSize.y / 2.0)
	for xCoords in range(-halfX, halfX):
		for yCoords in range(-halfY, halfY):
			var cellCoordinates = Vector2(xCoords, yCoords)
			set_cell(cellCoordinates, sourceID, atlasCoords, alternative)

## offset to show water after the rocks, outside the edge
@export var extraOffset = 3
var rocksSourceID = 1
var rocksAtlasCoords: Vector2i:
	get():
		return Vector2i(0, randi_range(0, 1))

var rocksAlternative = 0
func makeRocksEdge():
	var halfX = int(gridSize.x / 2.0) - extraOffset
	var halfY = int(gridSize.y / 2.0) - extraOffset
	
	for xCoords in range(-halfX - 1, halfX + 1):
		if abs(xCoords) != abs(halfX):
			continue
		
		for yCoords in range(-halfY, halfY):
			var cellCoordinates = Vector2(xCoords, yCoords)
			print("Making rock at: ", cellCoordinates)
			set_cell(cellCoordinates, rocksSourceID, rocksAtlasCoords, rocksAlternative)
	
	for xCoords in range(-halfX, halfY):
		for yCoords in range(-halfY - 1, halfY + 1):
			if abs(yCoords) != abs(halfY):
				continue
			var cellCoordinates = Vector2(xCoords, yCoords)
			print("Making rock at: ", cellCoordinates)
			set_cell(cellCoordinates, rocksSourceID, rocksAtlasCoords, rocksAlternative)

	# make a small rock at the corner
	var lastCellCoordinates = Vector2(halfX, halfY)
	set_cell(lastCellCoordinates, rocksSourceID, rocksAtlasCoords, rocksAlternative)