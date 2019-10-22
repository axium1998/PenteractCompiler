using System.Collections.Generic;
using PenteractCompiler.Helpers;

namespace PenteractCompiler.Geometry {
	public class Cube {
		public Cube(Face face) {
			Face = face;
		}

		public Face Face { get; }

		public bool Equals(Cube cube) {
			return Face.Equals(cube.Face);
		}
	}
}