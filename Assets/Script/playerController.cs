using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController", menuName = "InputController/PlayerController")]
public class playerController : InputController
{
    public override float returnHorizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public override float returnVertical()
    {
        return Input.GetAxisRaw("Vertical");
    }
}
