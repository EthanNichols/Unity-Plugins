using System.Collections.Generic;


namespace UnityEngine
{
		/// Here's the reason why these functions were extended from <see cref="Random"/>
		/// The issue is that extended functions need a reference object
		///
		/// So instead of being able to call: Random.Guassian( ... )
		/// You would have to call: new Random().Guassian( ... )
		///
		/// Which essentially hides the function and makes it more tedious to call
		/// By putting it under <see cref="Random2"/> makes it more obvious that
		/// there are additional random functions
		///
		/// Potentially in the future a new Random class will be created
		/// which copies all the functionality from <see cref="Random"/> and
		/// includes the additional functionality from <see cref="Random2"/>

		/// <summary>
		/// Additional Randomization functions that didn't fit in <see cref="Random"/>
		/// </summary>
		public static class Random2
		{
				/// <summary>
				/// Return a value from a symetrical normal distribution graph (shaped like a bell)
				/// </summary>
				/// <param name="mean">The value that should be the result the most (ie center of the curve)</param>
				/// <param name="deviation">The amount of deviation from the mean</param>
				/// <returns></returns>
				public static float Gaussion(this Random random, float mean, float deviation)
				{
						float val1 = Random.Range(0.0f, 1.0f);
						float val2 = Random.Range(0.0f, 1.0f);

						float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);
						return mean + deviation * gaussValue;
				}


				/// <summary>
				/// Get a random value from a list of values and their weights
				/// The higher the weight relative to other value's weights the higher probability that
				/// the value will be returned
				/// </summary>
				/// <param name="nonUniformList">
				/// X is the value that would be returned.
				/// Y is the weight of the value relative to other values in the list.
				/// </param>
				/// <returns>A random value that was pulled from the weighted list</returns>
				public static float NonUniform(this Random random, List<Vector2> nonUniformList)
				{
						float randomMax = 0;

						foreach (Vector2 value in nonUniformList)
						{
								randomMax += value.y;
						}

						float randomVal = Random.Range(0, randomMax);

						foreach (Vector2 value in nonUniformList)
						{
								randomVal -= value.y;

								if (randomVal <= 0)
								{
										return value.x;
								}
						}

						return 0;
				}
		}
}