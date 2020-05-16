using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace Polylabel_CSharp.Test
{
    public class PolylabelCSharpTest
    {
        [Theory]
        [InlineData("TestFiles/water1.json", 3865.85009765625, 2124.87841796875)]
        [InlineData("TestFiles/water2.json", 3263.5, 3263.5)]
        public void PolylabelJson(string fileName, double x, double y)
        {
            var jsonString = File.ReadAllText(fileName);
            var polygon = JsonConvert.DeserializeObject<double[][][]>(jsonString);
            var center = Polylabel.GetPolylabel(polygon);

            Assert.Equal(x, center[0]);
            Assert.Equal(y, center[1]);
        }
    }
}