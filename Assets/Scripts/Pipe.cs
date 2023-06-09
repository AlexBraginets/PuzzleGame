using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using ZergRush.ReactiveCore;
using Debug = UnityEngine.Debug;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeGetBallsLog _log;
    [SerializeField] private PipeBallsProvider _ballsProvider;
    private Ball[] _balls;
    public Ball[] Balls
    {
        get
        {
            // if (_balls != null) return _balls;
            var balls = _ballsProvider.GetBalls(out float[] distanceMap);
            StackTrace stackTrace = new StackTrace();
            StackFrame[] frames = stackTrace.GetFrames();
            string prefix = frames[1].GetMethod().DeclaringType.Name;
            _log.Log(prefix + gameObject.name + $"z: {transform.position.ToString("N5")}", balls, distanceMap);
            _balls = balls;
            return balls;
        }
    }

    [SerializeField] private IndexConfig _indexConfig;
    [HideInInspector] public Cell<int> CurrentLocation = new Cell<int>();
    public event Action OnLocationUpdated;
    public int OnLocationUpdatedLength => OnLocationUpdated.GetInvocationList().Length;
    public void LocationUpdated()
    {
        Debug.Log($"frame: {Time.frameCount}");
        OnLocationUpdated?.Invoke();
    }

    private void Awake()
    {
        _indexConfig.Init(CurrentLocation);
        _log.Clear();
    }

    public void Switch()
    {
        _balls = null;
        _indexConfig.Next();
    }
#if UNITY_EDITOR

    private void OnDestroy()
    {
        EditorUtility.SetDirty(_log);
    }
#endif
}