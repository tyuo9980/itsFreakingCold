using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUIBarGaugeExampleGUI : MonoBehaviour
{
	void OnGUI ()
	{
		GameObject gaugeObject = GameObject.Find("GUIBarGauge_Slide");
		if (gaugeObject != null)
		{
			GUIBarGauge gauge = gaugeObject.GetComponent<GUIBarGauge>();
			GUI.TextArea(new Rect(130, 100, 100, 20), "Slide:");
			gauge.Percentage =
				GUI.HorizontalSlider(
					new Rect(250, 105, 100, 20),
					gauge.Percentage,
					0, 100);
		}
		gaugeObject = GameObject.Find("GUIBarGauge_Clip");
		if (gaugeObject != null)
		{
			GUIBarGauge gauge = gaugeObject.GetComponent<GUIBarGauge>();
			GUI.TextArea(new Rect(130, 140, 100, 20), "Clip:");
			gauge.Percentage =
				GUI.HorizontalSlider(
					new Rect(250, 145, 100, 20),
					gauge.Percentage,
					0, 100);
		}
		gaugeObject = GameObject.Find("GUIBarGauge_Ammo");
		if (gaugeObject != null)
		{
			GUIBarGauge gauge = gaugeObject.GetComponent<GUIBarGauge>();
			GUI.TextArea(new Rect(130, 180, 100, 20), "Ammo:");
			gauge.Percentage =
				GUI.HorizontalSlider(
					new Rect(250, 185, 100, 20),
					gauge.Percentage,
					0, 100);
		}
		gaugeObject = GameObject.Find("GUIBarGauge_Health");
		if (gaugeObject != null)
		{
			GUIBarGauge gauge = gaugeObject.GetComponent<GUIBarGauge>();
			GUI.TextArea(new Rect(130, 220, 100, 20), "Health:");
			gauge.Percentage =
				GUI.HorizontalSlider(
					new Rect(250, 225, 100, 20),
					gauge.Percentage,
					0, 100);
		}
		gaugeObject = GameObject.Find("GUIBarGauge_NoGaugeTexture");
		if (gaugeObject != null)
		{
			GUIBarGauge gauge = gaugeObject.GetComponent<GUIBarGauge>();
			GUI.TextArea(new Rect(130, 260, 100, 20), "No Gauge:");
			gauge.Percentage =
				GUI.HorizontalSlider(
					new Rect(250, 265, 100, 20),
					gauge.Percentage,
					0, 100);
		}
		gaugeObject = GameObject.Find("GUIBarGauge_Siringe");
		if (gaugeObject != null)
		{
			GUIBarGauge gauge = gaugeObject.GetComponent<GUIBarGauge>();
			GUI.TextArea(new Rect(130, 300, 100, 20), "Siringe:");
			gauge.Percentage =
				GUI.HorizontalSlider(
					new Rect(250, 305, 100, 20),
					gauge.Percentage,
					0, 100);
		}
	}
}
