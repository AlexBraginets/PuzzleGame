using System.Linq;
using UnityEngine;

public class PipeWayDataProvider : MonoBehaviour
{
   [SerializeField] private WayDataProvider[] _wayDataProviders;

   public WayData[] WayDatas => _wayDataProviders.Select(x => x.GetWayData()).ToArray();

}
