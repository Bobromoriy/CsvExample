using CsvHelper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace CsvTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParserCanParseByIndex()
        {
            var parser = new CsvExample.UltraCoolCsvParser();

            var result = parser.ParseCsv(Resource1.DataFile);

            result.Should().HaveCount(20);

            var lastLine = Resource1.DataFile.Split(Environment.NewLine)[20]; //20 because we skipped the header row
            lastLine = lastLine.Replace("\"", ""); 
            var lastLineSplit = lastLine.Split(",");
            var lastRow = result[19];

            lastRow.Col1.Should().Be(lastLineSplit[0]);
            lastRow.Col2.Should().Be(lastLineSplit[1]);
            lastRow.Col3.Should().Be(lastLineSplit[2]);
            lastRow.Col4.Should().Be(lastLineSplit[3]);
            lastRow.Col5.Should().Be(lastLineSplit[4]);
            lastRow.Col6.Should().Be(lastLineSplit[5]);
            lastRow.Col7.Should().Be(lastLineSplit[6]);
            lastRow.Col8.Should().Be(lastLineSplit[7]);
            lastRow.Col9.Should().Be(lastLineSplit[8]);
            lastRow.Col10.Should().Be(lastLineSplit[9]);
            lastRow.Col11.Should().Be(lastLineSplit[10]);
            lastRow.Col12.Should().Be(lastLineSplit[11]);
            lastRow.Col13.Should().Be(lastLineSplit[12]);
            lastRow.Col14.Should().Be(lastLineSplit[13]);
            lastRow.Col15.Should().Be(lastLineSplit[14]);
        }

        [TestMethod]
        public void ParserCanParseByHeaders()
        {
            var parser = new CsvExample.UltraCoolCsvParser();

            // swapped "Title" and "Author"
            var result = parser.ParseCsv(Resource1.DataFile, ["Author", "Title", "Genre", "Publisher", "Publication Year", "ISBN", "Language", "Page Count", "Format", "Cover Type", "Best Seller", "Rating", "Condition", "Price", "Availability"]);

            result.Should().HaveCount(20);

            var lastLine = Resource1.DataFile.Split(Environment.NewLine)[20]; //20 because we skipped the header row
            lastLine = lastLine.Replace("\"", "");
            var lastLineSplit = lastLine.Split(",");
            var lastRow = result[19];

            lastRow.Col1.Should().Be(lastLineSplit[1]);  // swapped these two
            lastRow.Col2.Should().Be(lastLineSplit[0]);  // swapped these two 
            lastRow.Col3.Should().Be(lastLineSplit[2]);
            lastRow.Col4.Should().Be(lastLineSplit[3]);
            lastRow.Col5.Should().Be(lastLineSplit[4]);
            lastRow.Col6.Should().Be(lastLineSplit[5]);
            lastRow.Col7.Should().Be(lastLineSplit[6]);
            lastRow.Col8.Should().Be(lastLineSplit[7]);
            lastRow.Col9.Should().Be(lastLineSplit[8]);
            lastRow.Col10.Should().Be(lastLineSplit[9]);
            lastRow.Col11.Should().Be(lastLineSplit[10]);
            lastRow.Col12.Should().Be(lastLineSplit[11]);
            lastRow.Col13.Should().Be(lastLineSplit[12]);
            lastRow.Col14.Should().Be(lastLineSplit[13]);
            lastRow.Col15.Should().Be(lastLineSplit[14]);

        }
    }
}