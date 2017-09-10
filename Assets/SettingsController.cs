using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

	public struct resolution
	{
		public int width, height;

		public resolution(int w, int h)
		{
			width = w;
			height = h;
		}
	}

	resolution[] availableRes = new resolution[]
	{ 
		new resolution(800, 600), 
		new resolution(1280, 720),
		new resolution(1440, 900),
		new resolution(1920, 1080),
		new resolution(1920, 1200),
		new resolution(2560, 1600),
		new resolution(2880, 1800),
		new resolution(3840, 2160)
	};
	int currentResIndex = 2;

	public struct resSetting
	{
		public resolution currentRes;
		public bool full;
	}

	public Text resSelect;

	public resSetting currentSettings;

	public Toggle fullToggle;

	public void closeMenu ()
	{
		Destroy (this.gameObject);
	}

	public void cycleRes (bool leftRight) //left is false, right is true
	{
		if (leftRight == false) {
			currentResIndex--;
			if (currentResIndex < 0)
				currentResIndex = availableRes.Length - 1;
		} else {
			currentResIndex++;
			if (currentResIndex > availableRes.Length - 1)
				currentResIndex = 0;
		}

		currentSettings.currentRes = availableRes [currentResIndex];

		resSelect.text = currentSettings.currentRes.width + "x" + currentSettings.currentRes.height;
	}

	public void Apply ()
	{
		currentSettings.full = fullToggle.isOn;
		Screen.SetResolution (currentSettings.currentRes.width, currentSettings.currentRes.height, currentSettings.full);
	}
}
