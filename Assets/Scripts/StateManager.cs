using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    string _name;

   /* protected override void Awake()
    {
        base.Awake();
    }*/

    public string getName()
    {
        return _name;
    }

    public void setName(string newName)
    {
        _name = newName;
    }
}
