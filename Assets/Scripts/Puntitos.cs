using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntitos : MonoBehaviour
{
    public Transform[] puntos;


    public  Transform[] DevolverPuntos()
    {
        Debug.Log("Entre");
        Transform[] aux = this.puntos;
        return aux;

    }
}
