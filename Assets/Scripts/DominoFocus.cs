using System;
using Tobii.XR;
using UnityEngine;
using UnityEngine.Serialization;

public class DominoFocus : MonoBehaviour
{
    [SerializeField] private GameObject spawnManagerGameObject;
    private DominoSpawnManager _spawnManager;
    private FocusableDomino _winningDomino;
    private FocusableDomino _focusedGameObject;
    private float _focusedGameObjectTime;
    private const ControllerButton TriggerButton = ControllerButton.Trigger;

    private void Start()
    {
        _spawnManager = spawnManagerGameObject.GetComponent<DominoSpawnManager>();
        _winningDomino = _spawnManager.TheDomino;
    }

    private void Update()
    {
        UpdateFocusedObject();
        UpdateObjectState();
        _winningDomino = _spawnManager.TheDomino;
    }

    private void UpdateObjectState()
    {
        if (_focusedGameObject == _winningDomino && ControllerManager.Instance.GetButtonPressDown(TriggerButton))
        {
            _spawnManager.Shuffle();
        }
    }
    
    private void UpdateFocusedObject()
    {
        foreach (var focusedCandidate in TobiiXR.FocusedObjects)
        {
            var focusedObject = focusedCandidate.GameObject;
            if (focusedObject != null && focusedObject.GetComponent<FocusableDomino>())
            {
                SetNewFocusedObject(focusedObject);
                break;
            }
        }

        if (Time.time > _focusedGameObjectTime)
        {
            _focusedGameObjectTime = float.NaN;
            _focusedGameObject = null;
        }
    }
    
        private void SetNewFocusedObject(GameObject focusedObject)
        {
            _focusedGameObject = focusedObject.GetComponent<FocusableDomino>();
            _focusedGameObjectTime = Time.time;
        }
}
