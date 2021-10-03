using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    
    public static BulletFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static BulletFactory _instance;


    public Bullet bulletPrefab;
    public int bulletStock = 5;

    public ObjectPool<Bullet> pool;

    
    void Start()
    {
        _instance = this;

        //Creo un nuevo pool pasandole:
        //1.- La funcion que contiene la logica de instanciar el objeto (factoryMethod)
        //2.- La funcion que contiene la logica de que hacer al pedir el objeto (turnOnCallback)
        //3.- La funcion que contiene la logica de que hacer al devolver el objeto (turnOffCallback)
        //4.- La cantidad de objetos que se crearan en un principio
        //5.- Si es dinamico o no
        pool = new ObjectPool<Bullet>(BulletCreator, Bullet.TurnOn, Bullet.TurnOff, bulletStock);
    }

    //Funcion que contiene la logica de la creacion de la bala
    public Bullet BulletCreator() 
    {
        return Instantiate(bulletPrefab);
    }

    //Funcion que va a ser llamada cuando el objeto tenga que ser devuelto al Pool
    public void ReturnBullet(Bullet b)
    {
        pool.ReturnObject(b);
    }
}
