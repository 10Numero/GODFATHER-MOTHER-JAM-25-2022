using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ImageEffectCRT : ImageEffectBase
{
	[SerializeField]
	private float brightness = 27.0f;

	[SerializeField]
	private float contrast = 1f;

	[SerializeField, Range(0, 1)]
	private float alpha = .1f;
	
	// OnRenderImage() is called when the camera has finished rendering.
	protected override void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		material.SetFloat("_Brightness", brightness);
		material.SetFloat("_Contrast", contrast);
		material.SetFloat("_Alpha", alpha);
		
		Graphics.Blit(src, dst, material);
	}
}
