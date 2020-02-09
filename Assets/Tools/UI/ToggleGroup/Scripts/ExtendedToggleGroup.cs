using System;
using System.Collections.Generic;
using System.Linq;

// POSSIBLY DELETE / REWRITE

namespace UnityEngine.UI
{
		[AddComponentMenu("UI/Extended Toggle Group", 33)]
		[DisallowMultipleComponent]
		public class ExtendedToggleGroup : ToggleGroup
		{
				public List<Toggle> Toggles
				{
						get
						{
								return m_Toggles;
						}
				}


				/// <summary>
				/// Get the amount of toggles in this toggle group
				/// </summary>
				public int ToggleCount
				{
						get
						{
								return m_Toggles.Count;
						}
				}


				/// <summary>
				/// Get the amount of toggles that are active in this group
				/// </summary>
				public int ActiveToggleCount
				{
						get
						{
								return ActiveToggles().Count();
						}
				}


				/// <summary>
				/// Remove all of the toggles apart of this toggle group
				/// </summary>
				public void ClearToggles()
				{
						foreach (Toggle toggle in m_Toggles)
						{
								toggle.group = null;
						}

						m_Toggles.Clear();
				}


				/// <summary>
				/// Get the one toggle that is current active
				/// If 0 toggles are active, this function returns null
				/// If more than 1 toggles are active, this function returns null
				/// </summary>
				public Toggle GetActiveToggle()
				{
						int activeCount = ActiveToggleCount;
						if (activeCount == 1)
						{
								return ActiveToggles().FirstOrDefault();
						}

						Debug.LogWarning(string.Format("ActiveToggleCount: {0} Toggles, returning null", activeCount));
						return null;
				}
		}
}