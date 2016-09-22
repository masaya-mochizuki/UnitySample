using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HorizontalScroller : MonoBehaviour {

	public ScrollRect rect;
	public int index = 0;
	public float dulation = 1f;
	public int Length { get; protected set; }
	public bool IsScrolling { get; protected set; } //スクロール動作の実行中か

	void Awake()
	{
		//要素数はcontentのchildCountから取る
		Length = rect.content.childCount;
	}

	float GetTargetIndex () 
	{
		return (float)this.index / (float)(this.Length - 1);
	}

	public IEnumerator Scroll()
	{
		IsScrolling = true;

		float target = GetTargetIndex ();
		float now = rect.horizontalNormalizedPosition;

		if (Mathf.Abs(target - now) < float.Epsilon) {
			yield break;
		}

		float t = 0f;

		var col = new WaitWhile(()=> {
			t += Time.deltaTime;

			rect.horizontalNormalizedPosition = Mathf.Lerp (now, target, t / dulation);

			return t / dulation < 1f;
		});

		yield return col;

		rect.horizontalNormalizedPosition = target;
		IsScrolling = false;
	}
}
