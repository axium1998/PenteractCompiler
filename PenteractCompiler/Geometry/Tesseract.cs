using System.Collections.Generic;
using PenteractCompiler.Helpers;

namespace PenteractCompiler.Geometry {
	public class Tesseract {
		public Tesseract(Face face) {
			Face = face;
		}

		public Face Face { get; }
		public List<Cube> Cubes { get; private set; }

		public Tesseract SetCubes(params Cube[] cubes) {
			Cubes = new List<Cube>();
			foreach (var cube in cubes) Cubes.Add(cube);

			return this;
		}

		public bool Equals(Tesseract tesseract) {
			return Face.Equals(tesseract.Face);
		}
	}
}