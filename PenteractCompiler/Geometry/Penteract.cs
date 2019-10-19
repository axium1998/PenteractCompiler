using System.Collections.Generic;

namespace PenteractCompiler.Geometry {
	public class Penteract {
		public List<Tesseract> Tesseracts { get; private set; }

		public Penteract SetTesseracts(params Tesseract[] tesseracts) {
			Tesseracts = new List<Tesseract>();

			foreach (var tesseract in tesseracts) Tesseracts.Add(tesseract);

			return this;
		}
	}
}