using UnityEngine;
using System;

interface IInteract
{
    void Interact();
}

interface IEnemy
{
    void Hit(Action action);
}

interface IDeath
{
    void Collide(Action action);
}

interface ICannon
{
    void Cannon();
}

interface IWhale
{
    void Whale();
}

public class Interfaces : MonoBehaviour
{

}
