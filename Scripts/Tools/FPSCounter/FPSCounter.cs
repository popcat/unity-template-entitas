using TMPro;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public class FpsCounter : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _fpsText;

		[SerializeField]
		private float _hudRefreshRate = 1f;

		private float _timer;

		private void Update() {
			if (Time.unscaledTime > _timer) {
				var fps = (int)(1f / Time.unscaledDeltaTime);
				_fpsText.text = "FPS: " + fps;
				_timer = Time.unscaledTime + _hudRefreshRate;
			}
		}
	}
}