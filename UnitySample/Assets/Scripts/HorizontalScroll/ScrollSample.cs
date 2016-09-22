using UnityEngine;
using System.Collections;

public class ScrollSample : MonoBehaviour {

	[SerializeField]HorizontalScroller scroller;

	public void Next()
	{
		UpdateIndex(Mathf.Min(scroller.index+1,scroller.Length-1));
	}

	public void Prev()
	{
		UpdateIndex(Mathf.Max(scroller.index-1,0));
	}

	public void First()
	{
		UpdateIndex(0);
	}

	public void Last()
	{
		UpdateIndex(scroller.Length-1);
	}

	public void UpdateIndex(int index)
	{
		if ( scroller.IsScrolling || scroller.index == index) {
			return;
		}

		scroller.index = index;
		StartCoroutine(scroller.Scroll());
	}

}
