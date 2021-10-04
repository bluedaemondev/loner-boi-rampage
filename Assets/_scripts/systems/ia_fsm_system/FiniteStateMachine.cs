using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    IState _currentState = new BlankState();
    Dictionary<VictimEnum, IState> _allStates = new Dictionary<VictimEnum, IState>();

    public void OnUpdate()
    {
        _currentState.OnUpdate();
    }

    public void ChangeState(VictimEnum id)
    {
        if (!_allStates.ContainsKey(id)) return;

        _currentState.OnExit();
        _currentState = _allStates[id];
        _currentState.OnStart();
    }

    public void AddState(VictimEnum id, IState state)
    {
        if (_allStates.ContainsKey(id)) return;
        _allStates.Add(id, state);
    }
}
