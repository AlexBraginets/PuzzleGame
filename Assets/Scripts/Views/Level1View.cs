using Core;
using UnityEngine;

public class Level1View : MonoBehaviour
{
    [SerializeField] private TrackView _trackViewPrefab;
    private Level1 _level;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _level = new Level1();
        _level.Init();
        var trackView = Instantiate(_trackViewPrefab);
        trackView.Init(_level.Track1);
        trackView.name = "Track1";
        trackView.transform.parent = transform;
        trackView = Instantiate(_trackViewPrefab);
        trackView.Init(_level.Track2);
        trackView.name = "Track2";
        trackView.transform.parent = transform;
    }
}