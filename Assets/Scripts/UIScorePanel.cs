using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class UIScorePanel : MonoBehaviour
	{
		[SerializeField]
		private TMPro.TextMeshProUGUI[] m_scoreTexts;

		public void SetScore(int score)
		{
			foreach(TMPro.TextMeshProUGUI s in m_scoreTexts)
				if(s!=null)
			s.text = score.ToString();
		}
	}
}