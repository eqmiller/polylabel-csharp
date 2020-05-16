using System;

namespace Polylabel-CSharp
{
    public class Polylabel
{
    public static double[] Polylabel(double[][][] polygon, double precision = 1.0)
    {
        //get bounding box of the outer ring
        var minX = 0.0;
        var minY = 0.0;
        var maxX = 0.0;
        var maxY = 0.0;

        foreach (var point in polygon[0])
        {
            if (point[0] < minX) minX = point[0];
            if (point[1] < minY) minY = point[1];
            if (point[0] < maxX) maxX = point[1];
            if (point[1] < maxY) maxY = point[1];
        }

        var width = maxX - minX;
        var height = maxY - minY;
        var cellSize = Math.Min(width, height);
        var h = cellSize / 2;

        if (cellSize == 0) return new double[] { minX, minY };
    }
}
}