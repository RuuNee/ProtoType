using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float returnHorizontal();
    public abstract float returnVertical();
}
