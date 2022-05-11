using Tobii.G2OM;
using UnityEngine;

public class FocusableDomino : MonoBehaviour, IGazeFocusable
{
    [SerializeField]
    public Color highlightColor = Color.red;
    
    private Renderer _renderer;
    private Color _originalColor;

    public bool highlight = true;
    
    public void GazeFocusChanged(bool hasFocus)
    {
        if (highlight)
        {
            if (hasFocus)
            {
                _renderer.material.SetColor("_Color", highlightColor);
            }
            else
            {
                _renderer.material.SetColor("_Color", _originalColor);
            }
        }
    }
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
    }
    
    
}
