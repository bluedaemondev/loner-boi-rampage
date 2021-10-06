
/// <summary>
/// El orden en el que se encuentran en el enum, debe ser el mismo
/// que corresponde en el prefab de pickup generico, dentro del hijo
/// "asset container"
/// 
/// 0 => GO "DollarBill"
/// 1 => GO "Medkit"
/// ...
/// </summary>
public enum PickupType
{
    Cash,
    Health,
    Pistol,
    Shotgun
}
