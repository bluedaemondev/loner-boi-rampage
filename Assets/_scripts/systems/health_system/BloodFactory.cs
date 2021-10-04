using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodFactory : MonoBehaviour
{
    public static BloodFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static BloodFactory _instance;


    public Blood bloodPrefab;
    public int bloodStock = 5;

    public ObjectPool<Blood> pool;


    void Start()
    {
        _instance = this;

        //Creo un nuevo pool pasandole:
        //1.- La funcion que contiene la logica de instanciar el objeto (factoryMethod)
        //2.- La funcion que contiene la logica de que hacer al pedir el objeto (turnOnCallback)
        //3.- La funcion que contiene la logica de que hacer al devolver el objeto (turnOffCallback)
        //4.- La cantidad de objetos que se crearan en un principio
        //5.- Si es dinamico o no
        pool = new ObjectPool<Blood>(BloodCreator, Blood.TurnOn, Blood.TurnOff, bloodStock);
    }

    //Funcion que contiene la logica de la creacion de la bala
    public Blood BloodCreator()
    {
        return Instantiate(bloodPrefab);
    }

    //Funcion que va a ser llamada cuando el objeto tenga que ser devuelto al Pool
    public void ReturnBlood(Blood b)
    {
        pool.ReturnObject(b);
    }
}
