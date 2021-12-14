using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
  [SerializeField] private List<SOCharacter> characters;
  [SerializeField] private SOState state;
  [SerializeField] private CharacterMovementController _player;

  private PortMap _map;

  void Awake()
  {
    _map = FindObjectOfType<PortMap>();
  }

  void Start()
  {
    if (_map == null)
    {
      return;
    }

    foreach (var character in characters)
    {
      var building = DataSystem.Instance.Data.ports[state.PortID.ToString()].buildings[character.Building.ToString()];
      var x = building.x + character.OffsetX;
      var y = building.y + character.OffsetY;

      var worldPosition = _map.CellToWorld(new Vector3Int(x, y, 0));

      if (character.IsPlayer)
      {
        _player.CellPosition = new Vector3Int(x, y, 0);
      }
      else
      {
        Instantiate(character.Prefab, worldPosition, Quaternion.identity);
      }
    }
  }
}
