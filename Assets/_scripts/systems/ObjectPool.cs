using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Cuando yo hago un new ObjectPool voy a tener que setear de que tipo va a ser este.
//En este ejemplo va a ser ObjectPool<Bullet>
public class ObjectPool<T>
{
    Func<T> _factoryMethod; //Voy a guardar la logica que tendra mi ObjectPool para crear el objeto 

    List<T> _currentStock; //Lista donde voy a guardar los objetos disponibles a usar
    bool _isDynamic; //Si es dinamico va a crear mas objetos cuando la lista este vacia (todos objetos en uso)

    Action<T> _turnOnCallback; //Guardo la logica de la funcion que contiene Bullet para prenderse
    Action<T> _turnOffCallback; //Guardo la logica de la funcion que contiene Bullet para apagarse

    //Cada vez que yo haga un new ObjectPool para crear un pool, voy a tener que pasarle estos parametros obligatoriamente
    public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
    {
        _factoryMethod = factoryMethod;
        _turnOnCallback = turnOnCallback;
        _turnOffCallback = turnOffCallback;

        _isDynamic = isDynamic;

        _currentStock = new List<T>();

        for (int i = 0; i < initialStock; i++)
        {
            T obj = _factoryMethod();

            _turnOffCallback(obj);

            _currentStock.Add(obj);
        }
    }

    //Funcion que se va a llamar para dar un objeto de mi lista disponible
    public T GetObject()
    {
        var result = default(T); //Creo una referencia default del tipo de objeto a devolver

        if (_currentStock.Count > 0) //Si tengo stock en mi lista
        {
            result = _currentStock[0]; //Voy a devolver el primero de la lista
            _currentStock.RemoveAt(0); //Lo remuevo de mi lista de objetos listos para usar
        }
        else if (_isDynamic) //Sino, pero si es dinamico
        {
            result = _factoryMethod(); //Creo y devuelvo ese
        }

        _turnOnCallback(result); //Lo prendo con la logica del objeto

        return result;
    }

    //Funcion que se va a llamar cuando se quiere regresar el objeto a la lista de disponibles
    public void ReturnObject(T obj)
    {
        _turnOffCallback(obj); //Lo apago con la logica del objeto
        _currentStock.Add(obj); //Lo guardo nuevamente en la lista
    }
}
