using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung02
{
    class Vector3D
    {
        int X { get; set; }
        int Y { get; set; }
        int Z { get; set; }

        public Vector3D(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public static Vector3D operator +(Vector3D vec1, Vector3D vec2)
        {
            int X = vec1.X + vec2.X;
            int Y = vec1.Y + vec2.Y;
            int Z = vec1.Z + vec2.Z;

            return new Vector3D(X, Y, Z);
        }
        public static int operator *(Vector3D vec1, Vector3D vec2)
        {
            int X = vec1.X * vec2.X;
            int Y = vec1.Y * vec2.Y;
            int Z = vec1.Z * vec2.Z;

            return X + Y + Z;
        }
        public static Vector3D CrossProduct(Vector3D vec1, Vector3D vec2)
        {
            int X = vec1.Y * vec2.Z - vec1.Z * vec2.Y;
            int Y = vec1.Z * vec2.X - vec1.X * vec2.Z;
            int Z = vec1.X * vec2.Y - vec1.Y * vec2.Y;

            return new Vector3D(X, Y, Z);
        }
        public double Amount() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
    }
}
