using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Создавать больше файлов данных для разных врагов
[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle State")]
public class D_IdleState : ScriptableObject
{
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;
}
    

