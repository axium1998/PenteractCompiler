using System;
using System.Collections.Generic;
using System.Linq;
using PenteractCompiler.Geometry;
using PenteractCompiler.Helpers;

namespace PenteractCompiler {
    class Program {
        private static Penteract Penteract;
        private static LocationHolder start;
        private static LocationHolder end;
        private static LocationHolder current;
        
        static void Main(string[] args) {
            CreateTesseract();

            GetTravelPath();
            
            Console.WriteLine(start);
            Console.WriteLine(end);

            Travel();
        }

        private static void CreateTesseract() {
            Penteract = new Penteract();
            Penteract.SetTesseracts(
                new Tesseract(Face.North).SetCubes(
                    new Cube(Face.East),
                    new Cube(Face.West),
                    new Cube(Face.Up),
                    new Cube(Face.Down),
                    new Cube(Face.Ana),
                    new Cube(Face.Kata),
                    new Cube(Face.Strange),
                    new Cube(Face.Charm)
                ),
                new Tesseract(Face.South).SetCubes(
                    new Cube(Face.East),
                    new Cube(Face.West),
                    new Cube(Face.Up),
                    new Cube(Face.Down),
                    new Cube(Face.Ana),
                    new Cube(Face.Kata),
                    new Cube(Face.Strange),
                    new Cube(Face.Charm)
                ),
                new Tesseract(Face.East).SetCubes(
                    new Cube(Face.North),
                    new Cube(Face.South),
                    new Cube(Face.Up),
                    new Cube(Face.Down),
                    new Cube(Face.Ana),
                    new Cube(Face.Kata),
                    new Cube(Face.Strange),
                    new Cube(Face.Charm)
                ),
                new Tesseract(Face.West).SetCubes(
                    new Cube(Face.North),
                    new Cube(Face.South),
                    new Cube(Face.Up),
                    new Cube(Face.Down),
                    new Cube(Face.Ana),
                    new Cube(Face.Kata),
                    new Cube(Face.Strange),
                    new Cube(Face.Charm)
                ),
                new Tesseract(Face.Up).SetCubes(
                    new Cube(Face.North),
                    new Cube(Face.South),
                    new Cube(Face.East),
                    new Cube(Face.West),
                    new Cube(Face.Ana),
                    new Cube(Face.Kata),
                    new Cube(Face.Strange),
                    new Cube(Face.Charm)
                ),
                new Tesseract(Face.Down).SetCubes(
                    new Cube(Face.North),
                    new Cube(Face.South),
                    new Cube(Face.East),
                    new Cube(Face.West),
                    new Cube(Face.Ana),
                    new Cube(Face.Kata),
                    new Cube(Face.Strange),
                    new Cube(Face.Charm)
                ),
                new Tesseract(Face.Ana).SetCubes(
                    new Cube(Face.North),
                    new Cube(Face.South),
                    new Cube(Face.East),
                    new Cube(Face.West),
                    new Cube(Face.Up),
                    new Cube(Face.Down),
                    new Cube(Face.Strange),
                    new Cube(Face.Charm)),
                new Tesseract(Face.Kata).SetCubes(
                    new Cube(Face.North),
                    new Cube(Face.South),
                    new Cube(Face.East),
                    new Cube(Face.West),
                    new Cube(Face.Up),
                    new Cube(Face.Down),
                    new Cube(Face.Strange),
                    new Cube(Face.Charm)
                ),
                new Tesseract(Face.Strange).SetCubes(
                    new Cube(Face.North),
                    new Cube(Face.South),
                    new Cube(Face.East),
                    new Cube(Face.West),
                    new Cube(Face.Up),
                    new Cube(Face.Down),
                    new Cube(Face.Ana),
                    new Cube(Face.Kata)
                ),
                new Tesseract(Face.Charm).SetCubes(
                    new Cube(Face.North),
                    new Cube(Face.South),
                    new Cube(Face.East),
                    new Cube(Face.West),
                    new Cube(Face.Up),
                    new Cube(Face.Down),
                    new Cube(Face.Ana),
                    new Cube(Face.Kata)
                )
            );
        }

        private static void GetTravelPath() {
            var rand = new Random();
            var startTesseract = Penteract.Tesseracts[rand.Next(Penteract.Tesseracts.Count - 1)];
            var startCube = startTesseract.Cubes[rand.Next(startTesseract.Cubes.Count - 1)];
            start = new LocationHolder(startTesseract, startCube);
            
            rand = new Random();
            var endTesseract = Penteract.Tesseracts[rand.Next(Penteract.Tesseracts.Count - 1)];
            var endCube = endTesseract.Cubes[rand.Next(endTesseract.Cubes.Count - 1)];
            end = new LocationHolder(endTesseract, endCube);
        }

        private static void Travel() {
            current = start;
            var _inHyperCube = true;

            var travelFacesString = "";
            while (_inHyperCube) {
                var currentCubeFace = current.GetCube.Face;
                var currentTesseractFace = current.GetTesseract.Face;
                var oppositeCubeFace = Face.GetOppositeFace(currentCubeFace);
                var oppositeTesseractFace = Face.GetOppositeFace(currentTesseractFace);

                var TravelFaces = new List<Face> {};
                TravelFaces.AddRange(Face.Faces.Where
                    (face => !(face == currentCubeFace || face == oppositeCubeFace 
                                                       || face == currentTesseractFace 
                                                       || face == oppositeTesseractFace)));

                foreach (var travelFace in Face.Faces) {
                    if (travelFace != currentCubeFace || travelFace != oppositeCubeFace
                                                      || travelFace != currentTesseractFace 
                                                      || travelFace != oppositeTesseractFace)
                        travelFacesString += travelFace;
                }
                Console.WriteLine($"Travel Faces: {travelFacesString}");
                _inHyperCube = false;
            }
        }
    }
}