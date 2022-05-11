using Tobii.XR;
using UnityEngine;

public class GazePattern : MonoBehaviour
{
    [SerializeField] private bool _smoothMove = true;
    [SerializeField] [Range(1, 30)] private int _smoothMoveSpeed = 7;
    
    
}
