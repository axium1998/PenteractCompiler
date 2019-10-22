using PenteractCompiler.Geometry;

namespace PenteractCompiler.Helpers {
	public struct LocationHolder {
		private Tesseract Tesseract { get; }
		private Cube Cube { get; }

		public LocationHolder(Tesseract tesseract, Cube cube) {
			Tesseract = tesseract;
			Cube = cube;
		}

		public Cube GetCube => Cube;
		public Tesseract GetTesseract => Tesseract;

		public bool Equals(LocationHolder loc) {
			return Tesseract.Equals(loc.Tesseract) && Cube.Equals(loc.Cube);
		}

		public override string ToString() {
			return $"{Tesseract.Face}:{Cube.Face}";
		}
	}
}