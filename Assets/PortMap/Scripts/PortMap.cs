using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortMap : MonoBehaviour
{
  [SerializeField] private Grid _grid;

  public Vector3 CellToWorld(Vector3Int cellPosition)
  {
    var cellPositionInGrid = Vector3Int.Scale(cellPosition, new Vector3Int(1, -1, 0));
    cellPositionInGrid.x += 1;
    var worldPosition = _grid.CellToWorld(cellPositionInGrid);
    return worldPosition;
  }

  public Vector3Int WorldToCell(Vector3 worldPosition)
  {
    var cellPosition = _grid.WorldToCell(worldPosition);
    cellPosition.x -= 1;
    var cellPositionInGrid = Vector3Int.Scale(cellPosition, new Vector3Int(1, -1, 0));
    return cellPositionInGrid;
  }
}
