using System;
using System.Collections.Generic;
using System.Linq;
using PenteractCompiler.Geometry;
using PenteractCompiler.Helpers;

namespace PenteractCompiler {
    internal static class Program {
        private static Penteract _penteract;
        private static LocationHolder _start;
        private static LocationHolder _end;
        private static LocationHolder _current;

        private static void Main(string[] args) {
            CreateTesseract();

            GetTravelPath();
            
            Console.WriteLine($"Start:\t\t{_start}");
            Console.WriteLine($"End\t\t{_end}");
            Console.WriteLine("\n");
            
            Travel();
        }

        private static void CreateTesseract() {
            _penteract = new Penteract();
            _penteract.SetTesseracts(
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
            var startTesseract = _penteract.Tesseracts[rand.Next(_penteract.Tesseracts.Count - 1)];
            var startCube = startTesseract.Cubes[rand.Next(startTesseract.Cubes.Count - 1)];
            _start = new LocationHolder(startTesseract, startCube);
            
            rand = new Random();
            var endTesseract = _penteract.Tesseracts[rand.Next(_penteract.Tesseracts.Count - 1)];
            var endCube = endTesseract.Cubes[rand.Next(endTesseract.Cubes.Count - 1)];
            _end = new LocationHolder(endTesseract, endCube);
        }

        private static void Travel() {
            _current = _start;
            var inHyperCube = true;

            var travelFacesString = "";
            while (inHyperCube) {
                Console.WriteLine($"Current:\t{_current}");
                var currentCubeFace = _current.GetCube.Face;
                var currentTesseractFace = _current.GetTesseract.Face;
                var oppositeCubeFace = Face.GetOppositeFace(currentCubeFace);
                var oppositeTesseractFace = Face.GetOppositeFace(currentTesseractFace);

                var travelFaces = new List<Face> {};
                travelFaces.AddRange(Face.Faces.Where
                    (face => !(face.Equals(currentCubeFace) || face.Equals(oppositeCubeFace) 
                                                            || face.Equals(currentTesseractFace) 
                                                            || face.Equals(oppositeTesseractFace))));

                travelFacesString = travelFaces.ToArray().Aggregate(
                    travelFacesString, (current, travelFace) => current + (travelFace + " "));

                travelFacesString = travelFacesString.Trim();
                Console.WriteLine($"Travel Faces:\t{travelFacesString}");

                var inRoom = true;
                while (inRoom) {
                    Console.WriteLine($"Here is where I give you options on what to do, but I want to get this pushed soon");
                    inRoom = false;
                }
                
                inHyperCube = false;
            }
        }
    }
}