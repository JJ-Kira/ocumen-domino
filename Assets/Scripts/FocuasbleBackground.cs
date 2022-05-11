using Tobii.G2OM;
using UnityEngine;

public class FocuasbleBackground : MonoBehaviour, IGazeFocusable
{
    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus) Debug.Log("...");
    }
}
