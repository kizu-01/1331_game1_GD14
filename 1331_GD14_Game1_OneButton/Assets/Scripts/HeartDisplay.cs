using System.Collections.Generic;
using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private RectTransform _contentParent; // Changed to RectTransform
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _heart;

    // Adjusted spacing values for UI Screen Pixels
    [SerializeField] private float _heartSize = 60f;
    [SerializeField] private float _placementOffset = 0f;

    public List<GameObject> _heartAmount = new List<GameObject>(); // Initialized list

    public void MakeHearts()
    {
        foreach (var h in _heartAmount) { if (h != null) Destroy(h); }
        _heartAmount.Clear();

        for (var i = 0; i < _health.CurrentHealth; i++)
        {
            var heart = Instantiate(_heart, _contentParent);

            RectTransform rect = heart.GetComponent<RectTransform>();

            if (rect != null)
            {
                float yPos = _placementOffset - (i * _heartSize);
                rect.anchoredPosition = new Vector2(0f, yPos);
            }

            _heartAmount.Add(heart);
        }
    }

    public void RemoveHeart()
    {
        var heart = _heartAmount[_health.CurrentHealth];
        _heartAmount.Remove(heart);
        Destroy(heart);
    }
}
