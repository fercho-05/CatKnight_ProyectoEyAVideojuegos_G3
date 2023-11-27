using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    string _name;

    //Control de niveles
    public bool _level1 = false;
    public bool _level2 = false;
    public bool _finalBoos = false;

    public string getName()
    {
        return _name;
    }

    public void setName(string newName)
    {
        _name = newName;
    }

    //Control de niveles
    public bool getLevel1()
    {
        return _level1;
    }

    public void setLevel1(bool newLevel1)
    {
        _level1 = newLevel1;
    }
     ///////////
    public bool getLevel2()
    {
        return _level2;
    }

    public void setLevel2(bool newLevel2)
    {
        _level2 = newLevel2;
    }

    ////////////
    public bool getFinalBoss()
    {
        return _finalBoos;
    }

    public void setFinalBoss(bool newFinalBoss)
    {
        _finalBoos = newFinalBoss;
    }
}
