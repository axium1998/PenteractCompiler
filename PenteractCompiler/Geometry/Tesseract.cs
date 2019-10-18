using System.Collections.Generic;
using PenteractCompiler.Helpers;

namespace PenteractCompiler.Geometry {
    public class Tesseract {
        public Face Face { get; private set; }
        public List<Cube> Cubes { get; private set; }

        public Tesseract(Face face) {
            Face = face;
        }

        public Tesseract SetCubes(params Cube[] cubes) {
            Cubes = new List<Cube>();
            foreach (var cube in cubes) {
                Cubes.Add(cube);
            }

            return this;
        }
    }
}