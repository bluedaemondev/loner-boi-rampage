using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    //Creo un delegado para funciones que no devuelven nada y reciben como parametro un params object[]
    public delegate void EventReceiver(params object[] parameterContainer);

    //Diccionario donde voy a guardar cada evento al que se hayan registrado las funciones
    static Dictionary<string, EventReceiver> _events;

    public static void ResetEvents()
    {
        _events = new Dictionary<string, EventReceiver>();
    }

    public static void SubscribeToEvent(string eventType, EventReceiver listener)
    {
        if (_events == null) //Si el diccionario no existe
            _events = new Dictionary<string, EventReceiver>(); //Lo inicializo

        if (!_events.ContainsKey(eventType)) //Si el evento en mi diccionario no fue creado
        {
            _events.Add(eventType, null); //Lo creo
        }

        _events[eventType] += listener; //Registro la funcion que vino por parametro a ese evento
    }

    public static void Unsubscribe(string eventType, EventReceiver listener)
    {
        if (_events != null) //Si mi diccionario existe
        {
            if (_events.ContainsKey(eventType)) //Y contiene el evento
            {
                _events[eventType] -= listener; //Saco la funcion que vino por parametro del registro
            }
        }
    }

    //O TriggerEvent
    public static void ExecuteEvent(string eventType, params object[] parameters)
    {
        if (_events == null) //Si el diccionario no existe
        {
            Debug.Log("No events subscribed");
            return; //Salgo de la funcion
        }

        if (_events.ContainsKey(eventType)) //Si el evento existe en mi diccionario
        {
            if (_events[eventType] != null) //Y contiene alguna funcion registrada
            {
                _events[eventType](parameters); //Ejecuto todas las funciones registradas a ese evento
            }
        }
    }

    //Sobrecarga a ExceuteEvent
    public static void ExecuteEvent(string eventType)
    {
        ExecuteEvent(eventType, null);
    }

    ////Enum donde voy a agregar cada evento nuevo
    //public enum EventsType
    //{
    //    Event_GetHit,
    //    Event_HeroDefeated
    //}
}
