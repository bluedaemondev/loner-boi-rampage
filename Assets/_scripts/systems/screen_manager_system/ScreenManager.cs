using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    Stack<IScreen> _stack;

    public string lastResult;

    public static ScreenManager Instance {
        get
        {
            return _instance;
        }
    }
    private static ScreenManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        _stack = new Stack<IScreen>();
    }

    public void Pop()
    {
        if (_stack.Count <= 1) return;

        lastResult =_stack.Pop().Free();

        if (_stack.Count > 0)
        {
            _stack.Peek().Activate();
        }
    }

    public void Push(IScreen screen)
    {
        if (_stack.Count > 0)
        {
            _stack.Peek().Deactivate();
        }

        _stack.Push(screen);

        screen.Activate();
    }

    public void Push(string resource)
    {
        Debug.Log("Pushing " + resource);

        var go = Instantiate(Resources.Load<GameObject>(resource));
        Debug.Log(go.activeSelf);
        Push(go.GetComponent<IScreen>());
    }
  
}
