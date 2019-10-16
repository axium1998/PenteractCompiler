using PenteractCompiler.Helpers;

namespace PenteractCompiler.Geometry {
    public class Cube {
        public Face Face { get; }

        public Cube(Face face) {
            Face = face;
        }
    }
}