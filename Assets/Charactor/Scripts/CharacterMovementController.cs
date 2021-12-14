using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
  private Vector3Int _cellPosition;

  private PortMap _map;
  public float speed;
  public float stepSize;
  [SerializeField] private Transform _movePoint;
  [SerializeField] private SOState _state;
  private LogicalPortMap _logicalMap;

  private bool _isMoving = false;

  void Awake()
  {
    _map = FindObjectOfType<PortMap>();
  }

  void Start()
  {
    _cellPosition = _map.WorldToCell(transform.position);
    _movePoint.parent = null;
    _logicalMap = new LogicalPortMap(_state.PortID);
  }

  public Vector3Int CellPosition
  {
    get
    {
      return _cellPosition;
    }
    set
    {
      _cellPosition = value;
      transform.position = _map.CellToWorld(_cellPosition);
    }
  }

  public void Move(Vector3Int direction)
  {
    if (_isMoving)
    {
      return;
    }
    _isMoving = true;

    _cellPosition += DirectionOnGrid(direction);

    if (_logicalMap.CollisionAt(new Vector2Int(_cellPosition.x, _cellPosition.y)))
    {

    }
    else if (_logicalMap.BuildingAt(_cellPosition) != 0)
    {
      _state.EnterBuilding(BUILDING_STATE.HARBOR);
      _cellPosition += DirectionOnGrid(Vector3Int.down);
      _movePoint.position = _map.CellToWorld(_cellPosition);
      _isMoving = false;
    }
    else
    {
      _movePoint.position = _map.CellToWorld(_cellPosition);
      StartCoroutine(MoveCoroutine());
    }
  }

  private Vector3Int DirectionOnGrid(Vector3Int direction)
  {
    return Vector3Int.Scale(direction, new Vector3Int(1, -1, 0));
  }

  private IEnumerator MoveCoroutine()
  {
    while (Vector3.Distance(transform.position, _movePoint.position) > float.Epsilon)
    {
      transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, speed * Time.deltaTime);
      yield return null;
    }
    _isMoving = false;
  }
}
