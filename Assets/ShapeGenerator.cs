using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator   {
	ShapeSettings settings;
	INoiseFilter[] noiseFilter;
	public MinMax elevationMinMax;

	public void UpdateSettings(ShapeSettings _settings){
		settings = _settings;
		noiseFilter = new INoiseFilter[settings.noiseLayers.Length];

		for (int i = 0; i < noiseFilter.Length; i++) {
			noiseFilter [i] = NoiseFilterFactory.CreateNoiseFilter (settings.noiseLayers [i].noiseSettings);
		}

		elevationMinMax = new MinMax();
	}

	public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere){
		float firstLayerValue = 0;
		float elevation = 0;

		if (noiseFilter.Length > 0) {
			firstLayerValue = noiseFilter [0].Evaluate (pointOnUnitSphere);
			if (settings.noiseLayers [0].enables) {
				elevation = firstLayerValue;
			}
		}
		for (int i = 1; i < noiseFilter.Length; i++) {
			if (settings.noiseLayers [i].enables) {
				float mask = (settings.noiseLayers[i].useFirstLayerAsMask ? firstLayerValue : 1);
				elevation += noiseFilter [i].Evaluate (pointOnUnitSphere) * mask;
			}
		}
		elevation = settings.planetRadius * (1+elevation);
		elevationMinMax.AddValue(elevation);
		return pointOnUnitSphere * elevation;
	}
}
