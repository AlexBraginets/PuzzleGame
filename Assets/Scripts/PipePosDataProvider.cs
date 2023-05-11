using System.Linq;
using UnityEngine;

public class PipePosDataProvider : MonoBehaviour
{
   [SerializeField] private PosDataProvider[] _posDataProviders;
   public PosData[] PosDatas => _posDataProviders.Select(x => x.GetPosData()).ToArray();

}
