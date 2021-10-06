using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    void Subscribe(IObserver obs);

    void Unsubscribe(IObserver obs);

    void NotifyToObservers(string action);
}
