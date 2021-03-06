﻿using UnityEngine;

[System.Serializable]
public class LocalizationItem {
	public string key;
	public Font overrideLanguageFont = null;
	[UnityEngine.TextArea(3, 10)]
	public string value;
}

[System.Serializable]
public class LocalizationData {

	public Font defaultLanguageFont;
	public LocalizationItem[] localizationItems;
}
