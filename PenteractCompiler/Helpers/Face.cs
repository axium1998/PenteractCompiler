using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace PenteractCompiler.Helpers {
    public class Face {
        public static readonly List<Face> Faces = new List<Face> {
            North, South, East, West, Up, Down, Ana, Kata, Strange, Charm
        };
        private string Value { get; }
        private Face(string val) {
            Value = val;
        }
        
        public static Face North => new Face("North");  
        public static Face South => new Face("South");
        public static Face East => new Face("East");
        public static Face West => new Face("West");
        public static Face Up => new Face("Up");
        public static Face Down => new Face("Down");
        public static Face Ana => new Face("Ana");
        public static Face Kata => new Face("Kata");
        public static Face Strange => new Face("Strange");
        public static Face Charm => new Face("Charm");

        public static Face GetOppositeFace(Face face) {
            switch(face.Value) {
                case "North": return South;
                case "South": return North;
                case "East": return West;
                case "West": return East;
                case "Up": return Down;
                case "Down": return Up;
                case "Ana": return Kata;
                case "Kata": return Ana;
                case "Strange": return Charm;
                case "Charm": return Strange;
                default: throw new ArgumentException($"{face.Value} is not a valid Face value.");
            }
        }

        public bool Equals(Face face) {
            return face.Value == Value;
        }
        public override string ToString() => Value;
    }
}