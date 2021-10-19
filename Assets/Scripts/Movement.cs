using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// - Store player / npc position as tile position (player at 1,1)
// - Take input when player is not transitioning from tile to tile
// - If player moves left, target position is position.x-1, position.y
// - Store this to targetPosition and mark player to be transitioning / busy
// - While player is not at targetPosition, move player torwards target
// - When targetPosition is reached, mark player again to be able to accept input
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
    }
}
