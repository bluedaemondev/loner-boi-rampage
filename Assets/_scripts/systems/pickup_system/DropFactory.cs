using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFactory : MonoBehaviour
{
    public static DropFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static DropFactory _instance;


    public Pickup pickupPrefab;
    public int pickupStock = 5;

    public ObjectPool<Pickup> pool;


    void Start()
    {
        _instance = this;

        //Creo un nuevo pool pasandole:
        //1.- La funcion que contiene la logica de instanciar el objeto (factoryMethod)
        //2.- La funcion que contiene la logica de que hacer al pedir el objeto (turnOnCallback)
        //3.- La funcion que contiene la logica de que hacer al devolver el objeto (turnOffCallback)
        //4.- La cantidad de objetos que se crearan en un principio
        //5.- Si es dinamico o no
        pool = new ObjectPool<Pickup>(PickupCreator, Pickup.TurnOn, Pickup.TurnOff, pickupStock);
    }

    //Funcion que contiene la logica de la creacion de la bala
    public Pickup PickupCreator()
    {
        return Instantiate(pickupPrefab);
    }

    //Funcion que va a ser llamada cuando el objeto tenga que ser devuelto al Pool
    public void ReturnPickup(Pickup b)
    {
        pool.ReturnObject(b);
    }
}
