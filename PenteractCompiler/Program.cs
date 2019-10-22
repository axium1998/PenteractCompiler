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

			var traveled = new List<LocationHolder>();
			while (inHyperCube) {
				Console.Clear();
				Console.WriteLine($"Start:\t\t{_start}");
				Console.WriteLine($"End\t\t{_end}\n");
				Console.WriteLine($"Current:\t{_current}");
				
				var travelFacesString = "";
				traveled.Add(_current);
				var currentCubeFace = _current.GetCube.Face;
				var currentTesseractFace = _current.GetTesseract.Face;
				var oppositeCubeFace = Face.GetOppositeFace(currentCubeFace);
				var oppositeTesseractFace = Face.GetOppositeFace(currentTesseractFace);

				var travelFaces = new List<Face>();
				travelFaces.AddRange(Face.Faces.Where
				(x => !(x.Equals(currentCubeFace) || x.Equals(oppositeCubeFace)
				                                        || x.Equals(currentTesseractFace)
				                                        || x.Equals(oppositeTesseractFace))));

				travelFacesString = travelFaces.ToArray().Aggregate(
					travelFacesString, (current, travelFace) => current + (travelFace + " "));

				travelFacesString = travelFacesString.Trim();
				Console.WriteLine($"Travel Faces:\t{travelFacesString}");
				
				for (int k = 0; k < 6; k++) {
					Console.WriteLine($"[{k+1}]:\t{travelFaces[k]}");
				}
				Console.WriteLine("[7]:\tFlip");
				Console.WriteLine("[8]:\tTravel Map");
				Console.WriteLine("[9]:\tExit (will NOT save progress");

				if (_current.Equals(_end)) {
					Console.WriteLine("[10]:\tYou've made it! Leave the hypercube.");
				}

				var inRoom = true;
				Face face;
				while (inRoom) {
					var choice = Console.ReadLine();
					switch (choice) {
						case "1":
							face = travelFaces[0];
							_current = new LocationHolder(_current.GetTesseract, new Cube(face));
							inRoom = false;
							break;
						
						case "2":
							face = travelFaces[1];
							_current = new LocationHolder(_current.GetTesseract, new Cube(face));
							inRoom = false;
							break;
						
						case "3": 
							face = travelFaces[2];
							_current = new LocationHolder(_current.GetTesseract, new Cube(face));
							inRoom = false;
							break;
						
						case "4":
							face = travelFaces[3];
							_current = new LocationHolder(_current.GetTesseract, new Cube(face));
							inRoom = false;
							break;
						
						case "5":
							face = travelFaces[4];
							_current = new LocationHolder(_current.GetTesseract, new Cube(face));
							inRoom = false;
							break;
						
						case "6":
							face = travelFaces[5];
							_current = new LocationHolder(_current.GetTesseract, new Cube(face));
							inRoom = false;
							break;
						
						case "7":
							_current = new LocationHolder(new Tesseract(_current.GetCube.Face), new Cube(_current.GetTesseract.Face));
							inRoom = false;
							break;
						
						case "8":
							var travelString = traveled.Aggregate("", (current, loc) => current + (loc + " "));

							travelString = travelString.Trim();
							Console.WriteLine($"Travel Path: {travelString}");
							break;
						
						case "9":
							inRoom = false;
							inHyperCube = false;
							break;
						
						default:
							if (_current.Equals(_end)) {
								Console.WriteLine("Leaving the hypercube");
								inRoom = false;
								inHyperCube = false;
								break;
							}
							else {
								Console.WriteLine($"Oops! {choice} is not a choice. Please try again.");
								break;
							}
					}
				}
			}
		}
	}
}