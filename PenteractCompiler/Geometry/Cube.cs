using System.Collections.Generic;
using PenteractCompiler.Helpers;

namespace PenteractCompiler.Geometry {
    public class Cube {
        public Face Face { get; }
        public List<Face> Faces { get; private set; }
        public Cube(Face face) {
            Face = face;
        }

        public Cube SetFaces(params Face[] faces) {
            Faces = new List<Face>();
            foreach (var face in faces) {
                Faces.Add(face);
            }

            return this;
        }
    }
}