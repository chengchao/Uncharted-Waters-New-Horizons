using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// - Store player / npc position as tile position (player at 1,1)
// - Take input when player is not transitioning from tile to tile
// - If player moves left, target position is position.x-1, position.y
// - Store this to targetPosition and mark player to be transitioning / busy
// - While player is not at targetPosition, move player torwards target
// - When targetPosition is reached, mark player again to be able to accept input

// 1. Decide the axis of movement / direction based on player input (left / right / up / down) .
// 2. Get the next closest tile center/position based on input (depending on your character pivot).
// 3. Set some state variable so you know not to take input while moving (unless you do this by design).
// 3. Move to target by using lerp / smoothdamp on your transform.
// 4. When target is reached, allow input again.

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float stepSize = 1f;
    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= float.Epsilon)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(horizontal) == 1f)
            {
                movePoint.position += new Vector3(stepSize * horizontal, 0f, 0f);
            }
            else if (Mathf.Abs(vertical) == 1f)
            {
                movePoint.position += new Vector3(0, stepSize * vertical, 0f);
            }
        }
    }
}
