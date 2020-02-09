using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangeExample : MonoBehaviour
{
		[RangeSlider(0.0f, 10.0f)]
		public ValueRange floatRangeSlider;

		[RangeSlider(-10, 10)]
		public ValueIntRange intRangeSlider;

		public ValueRange floatRange;

		public ValueIntRange intRange;


		void Start()
    {
				Debug.Log("Float Range Slider " + floatRangeSlider.GetRandomValue());
				Debug.Log("Int Range Slider " + intRangeSlider.GetRandomValue());
				Debug.Log("Float Range " + floatRange.GetRandomValue());
				Debug.Log("Int Range " + intRange.GetRandomValue());
		}
}
