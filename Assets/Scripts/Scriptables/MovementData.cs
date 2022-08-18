using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Movement Data", menuName = "Data/Movement Data")]
public class MovementData : ScriptableObject
{
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] Vector2 horizontalBounds;

    public float VerticalSpeed => verticalSpeed;
    public float HorizontalSpeed
    {
        get
        {
            return horizontalSpeed;
        }
        set
        {
            horizontalSpeed = value;
        }
    }

    public Vector2 HorizontalBounds => horizontalBounds;

}
