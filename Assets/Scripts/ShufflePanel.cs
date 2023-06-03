using UnityEngine;
using UnityEngine.UI;

public class ShufflePanel : MonoBehaviour
{
   [SerializeField] private Button _shuffleButton;
   [SerializeField] private Shuffler _shuffler;
   
   private void Awake()
   {
      _shuffleButton.onClick.AddListener(Shuffle);
   }

   private void Shuffle()
   {
      _shuffleButton.enabled = false;
      _shuffler.enabled = true;
      _shuffler.OnFinished += () => gameObject.SetActive(false);

   }
}
