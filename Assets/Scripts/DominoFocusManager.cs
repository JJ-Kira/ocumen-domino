using Tobii.XR;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class DominoFocusManager : MonoBehaviour
{
    public TobiiXR_Settings settings;
    
    private void Awake()
    {
        TobiiXR.Start(settings);
    }
}