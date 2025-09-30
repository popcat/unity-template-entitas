using System;
using System.Collections;
using UnityEngine;

namespace BartekNizio.Unity.Template.Entitas
{
	public class GameObjectEOF : MonoBehaviour
	{
		//todo add counter to dynamically scale output to not produce less than/s
		
		public int targetFrameRate;
		public int minFrameRate;
		public int vSyncCount;
		public float timeReserve;
		public int targetOutput;
		public int minOutputPerSec;

		private int _output;
		private int _outputInLastSec;
		private int _frameRate;
		private float _timeReserve;
		
		private void Start()
		{
			//Application.targetFrameRate = targetFrameRate;
			QualitySettings.vSyncCount = vSyncCount;
			_output = targetOutput;
			_frameRate = targetFrameRate;
			_timeReserve = timeReserve;
		}

		public void Update()
		{
			
			if (Input.GetKeyDown(KeyCode.G)) {
				StartCoroutine(GenerateGameObjects());
				StartCoroutine(OutputManager());
			}
		}

		private IEnumerator GenerateGameObjects()
		{
			while (_output > 0) {
				yield return new WaitForEndOfFrame();
				var timeLimit = 1f / _frameRate;
				var outputInFrame = 0;
				while (_output > 0) {
					var passedTime = Time.realtimeSinceStartup - Time.unscaledTime;
					if (timeLimit - passedTime < _timeReserve) {
						//Debug.Log($"break: {i}");
						break;
					}

					var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
					go.transform.SetParent(transform);
					go.SetActive(false);
					_outputInLastSec++;
					outputInFrame++;
					_output--;
				}

				if (outputInFrame == 0) {
					ManageOutput();
				}
			}
			
			Debug.Log("EOF Fisnished");
		}

		private IEnumerator OutputManager()
		{
			while (_output > 0) {
				yield return new WaitForSeconds(1);
				if (_outputInLastSec < minOutputPerSec) {
					ManageOutput();
				}
				_outputInLastSec = 0;
			}
		}

		private void ManageOutput()
		{
			if (_frameRate > minFrameRate) {
				_frameRate = (int)(_frameRate * 0.5f);
			}
			else {
				_timeReserve *= 0.5f;
				_frameRate = targetFrameRate;
			}
			
			Debug.Log($"TFR: {_frameRate}, TR: {_timeReserve}");
		}
	}
}