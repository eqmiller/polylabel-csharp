using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace Polylabel_CSharp.Test
{
    public class PolylabelTest
    {
        [Theory]
        [InlineData("TestFiles/water1.json", 3865.85009765625, 2124.87841796875)]
        [InlineData("TestFiles/water2.json", 3263.5, 3263.5)]
        public void PolylabelJson(string fileName, double expectedX, double expectedY)
        {
            var jsonString = File.ReadAllText(fileName);
            var polygon = JsonConvert.DeserializeObject<double[][][]>(jsonString);
            var center = Polylabel.GetPolylabel(polygon, debug: true);

            Assert.Equal(expectedX, center[0]);
            Assert.Equal(expectedY, center[1]);
        }

        [Fact]
        public void DegeneratePolygons()
        {
            var polygon = new double[][][] {
                new double[][] {
                    new double[] { 0, 0 },
                    new double[] { 1, 0 },
                    new double[] { 2, 0 },
                    new double[] { 0, 0 }
                }
            };

            var polylabel = Polylabel.GetPolylabel(polygon);

            Assert.Equal(new double[] { 0, 0 }, polylabel);

            polygon = new double[][][] {
                new double[][] {
                    new double[] { 0, 0 },
                    new double[] { 1, 0 },
                    new double[] { 1, 1 },
                    new double[] { 1, 0 },
                    new double[] { 0, 0 }
                }
            };

            polylabel = Polylabel.GetPolylabel(polygon);

            Assert.Equal(new double[] { 0, 0 }, polylabel);
        }
    }
}