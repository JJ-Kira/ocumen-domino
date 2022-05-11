using UnityEngine;
using Tobii.XR;

public class PostCalibrationVisualizerView : MonoBehaviour
{
    private GameObject _combinedGazePointPivot;
    private TobiiXR_EyeTrackingData _latestData;

    private void Awake()
    {
        // Get relevant game objects. 
        var parentTransform = transform.Find("Post-Calibration Visualizer");
        _combinedGazePointPivot = parentTransform.Find("Combined Gaze Point Pivot").gameObject;

        _combinedGazePointPivot.SetActive(true);
    }

    private void Update()
    {
        _latestData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.Local);

        DisplayCombinedVisualization();
    }

    private void DisplayCombinedVisualization()
    {
        _combinedGazePointPivot.transform.localPosition = _latestData.GazeRay.Origin;
        _combinedGazePointPivot.transform.forward = transform.TransformDirection(_latestData.GazeRay.Direction);
    }
}