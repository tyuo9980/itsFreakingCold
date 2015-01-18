using UnityEngine;
using System.Collections;

public enum GUIBarGaugeOnTop
{
	Gauge,
	Value
}

public enum GUIBarGaugeDirection
{
	BottomToTop,
	TopToBottom,
	LeftToRight,
	RightToLeft
}

public enum GUIBarGaugeMode
{
	Slide,
	Clip
}

[ExecuteInEditMode]
public class GUIBarGauge : MonoBehaviour
{
	public Camera Camera;
	
	public TextAnchor Anchor = TextAnchor.LowerLeft;
	
	public Texture2D GaugeTexture;
	
	public Texture2D ValueTexture;
	
	public Vector2 ValueTexturePixelInset = Vector2.zero;
	
	public GUIBarGaugeOnTop OnTop = GUIBarGaugeOnTop.Gauge;
	
	public GUIBarGaugeDirection Direction = GUIBarGaugeDirection.BottomToTop;

	public GUIBarGaugeMode Mode = GUIBarGaugeMode.Slide;
	
	public float Percentage = 100f;
	
	private Camera GUICamera
	{
		get
		{
			Camera camera = (Camera != null) ? Camera : Camera.main;
	        GUILayer guiLayer = camera.gameObject.GetComponent<GUILayer>();
	        if (guiLayer == null)
				camera.gameObject.AddComponent<GUILayer>();
			return camera;
		}
	}
	
	void Update()
	{
		Percentage = Mathf.Clamp(Percentage, 0f, 100f);
	}
	
	void OnGUI()
	{
		if (Event.current.type == EventType.Repaint)
		{
			switch (OnTop)
			{
				case GUIBarGaugeOnTop.Gauge:
					DrawValueTexture();
					DrawGaugeTexture();
					break;
				case GUIBarGaugeOnTop.Value:
					DrawGaugeTexture();
					DrawValueTexture();
					break;
			}
		}
	}
	
	private void DrawGaugeTexture()
	{
		if (GaugeTexture != null)
		{
			Vector2 screenPosition = GetScreenPosition(GaugeTexture, Vector2.zero);

			GUI.DrawTexture(
				new Rect(
					screenPosition.x,
					screenPosition.y,
					GaugeTexture.width * transform.localScale.x,
					GaugeTexture.height * transform.localScale.y),
				GaugeTexture,
				ScaleMode.StretchToFill);
		}
	}
	
	private void DrawValueTexture()
	{
		if (ValueTexture != null)
		{
			Vector2 screenPosition = GetScreenPosition(ValueTexture, ValueTexturePixelInset);
			
			Rect clippingRectangle =
				new Rect(
					screenPosition.x,
					screenPosition.y,
					ValueTexture.width * transform.localScale.x,
					ValueTexture.height * transform.localScale.y);
			Vector2 valuePosition = Vector2.zero;
			switch (Direction)
			{
				case GUIBarGaugeDirection.BottomToTop:
					valuePosition.y = (ValueTexture.height - (ValueTexture.height * (Percentage / 100f))) * transform.localScale.y;
					if (Mode == GUIBarGaugeMode.Clip)
					{
						clippingRectangle.y += valuePosition.y;
						clippingRectangle.height -= valuePosition.y;
						valuePosition.y = -valuePosition.y;
					}
					break;
				case GUIBarGaugeDirection.TopToBottom:
					valuePosition.y = -((ValueTexture.height - (ValueTexture.height * (Percentage / 100f))) * transform.localScale.y);
					if (Mode == GUIBarGaugeMode.Clip)
					{
						clippingRectangle.height += valuePosition.y;
						valuePosition.y = 0f;
					}
					break;
				case GUIBarGaugeDirection.LeftToRight:
					valuePosition.x = -((ValueTexture.width - (ValueTexture.width * (Percentage / 100f))) * transform.localScale.x);
					if (Mode == GUIBarGaugeMode.Clip)
					{
						clippingRectangle.width += valuePosition.x;
						valuePosition.x = 0f;
					}
					break;
				case GUIBarGaugeDirection.RightToLeft:
					valuePosition.x = (ValueTexture.width - (ValueTexture.width * (Percentage / 100f))) * transform.localScale.x;
					if (Mode == GUIBarGaugeMode.Clip)
					{
						clippingRectangle.x += valuePosition.x;
						clippingRectangle.width -= valuePosition.x;
						valuePosition.x = -valuePosition.x;
					}
					break;
			}
		
			GUI.BeginGroup(clippingRectangle);
			GUI.DrawTexture(
				new Rect(
					valuePosition.x,
					valuePosition.y,
					ValueTexture.width * transform.localScale.x,
					ValueTexture.height * transform.localScale.y),
				ValueTexture,
				ScaleMode.StretchToFill);
			GUI.EndGroup();
		}
	}

	private Vector2 GetScreenPosition(Texture2D texture, Vector2 pixelInset)
	{
		Vector2 result;
		result = GUICamera.ViewportToScreenPoint(transform.position);
		result.y = GUICamera.GetScreenHeight() - result.y;
		switch (Anchor)
		{
			case TextAnchor.LowerCenter:
				result.x -= texture.width / 2f * transform.localScale.x;
				result.y -= texture.height * transform.localScale.y;
				result.x += pixelInset.x * transform.localScale.x;
				result.y -= pixelInset.y * transform.localScale.y;
				break;
			case TextAnchor.LowerLeft:
				result.y -= texture.height * transform.localScale.y;
				result.x += pixelInset.x * transform.localScale.x;
				result.y -= pixelInset.y * transform.localScale.y;
				break;
			case TextAnchor.LowerRight:
				result.x -= texture.width * transform.localScale.x;
				result.y -= texture.height * transform.localScale.y;
				result.x -= pixelInset.x * transform.localScale.x;
				result.y -= pixelInset.y * transform.localScale.y;
				break;
			case TextAnchor.MiddleCenter:
				result.x -= texture.width / 2f * transform.localScale.x;
				result.y -= texture.height / 2f * transform.localScale.y;
				result.x += pixelInset.x * transform.localScale.x;
				result.y += pixelInset.y * transform.localScale.y;
				break;
			case TextAnchor.MiddleLeft:
				result.y -= texture.height / 2f * transform.localScale.y;
				result.x += pixelInset.x * transform.localScale.x;
				result.y += pixelInset.y * transform.localScale.y;
				break;
			case TextAnchor.MiddleRight:
				result.x -= texture.width * transform.localScale.x;
				result.y -= texture.height / 2f * transform.localScale.y;
				result.x -= pixelInset.x * transform.localScale.x;
				result.y += pixelInset.y * transform.localScale.y;
				break;
			case TextAnchor.UpperCenter:
				result.x -= texture.width / 2f * transform.localScale.x;
				result.x += pixelInset.x * transform.localScale.x;
				result.y += pixelInset.y * transform.localScale.y;
				break;
			case TextAnchor.UpperLeft:
				result.x += pixelInset.x * transform.localScale.x;
				result.y += pixelInset.y * transform.localScale.y;
				break;
			case TextAnchor.UpperRight:
				result.x -= texture.width * transform.localScale.x;
				result.x -= pixelInset.x * transform.localScale.x;
				result.y += pixelInset.y * transform.localScale.y;
				break;
		}
		return result;
	}
}
