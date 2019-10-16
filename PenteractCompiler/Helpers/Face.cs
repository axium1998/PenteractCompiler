using System;

namespace PenteractCompiler.Helpers {
    public class Face {
        private string Value { get; }
        private Face(string val) {
            Value = val;
        }
        
        public Face North => new Face("North");  
        public Face South => new Face("South");
        public Face East => new Face("East");
        public Face West => new Face("West");
        public Face Up => new Face("Up");
        public Face Down => new Face("Down");
        public Face Ana => new Face("Ana");
        public Face Kata => new Face("Kata");
        public Face Strange => new Face("Strange");
        public Face Charm => new Face("Charm");

        public override string ToString() => Value;
    }
}