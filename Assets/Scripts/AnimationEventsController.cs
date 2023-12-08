using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventsController : MonoBehaviour
{
    public void OnAttack()
    {
        CharacterPlataformerController.Instance.Attack();
    }
}
