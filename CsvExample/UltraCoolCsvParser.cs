using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Reflection;

namespace CsvExample
{
    public class UltraCoolCsvParser
    {
        /// <summary>
        /// Will parse the provided string <paramref name="csvData"/> into a list of <see cref="ParsedResult"/>
        /// In case <paramref name="headers"/> are null or emptu, will map <see cref="ParsedResult.Col1"/> to the first columnn and so on
        /// In case <paramref name="headers"/> are provided, will map <see cref="ParsedResult.Col1"/> to the <paramref name="headers"/>[0] column and etc
        /// </summary>
        /// <param name="csvData"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public List<ParsedResult> ParseCsv(string csvData, string[] headers = null)
        {
            var toReturn = new List<ParsedResult>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Quote = '\"',
                MissingFieldFound = null, // we don't do anything if the file does not have a columm from the map
            };

            using (StringReader reader = new StringReader(csvData))
            using (var csv = new CsvReader(reader, config))
            {
                // map by headers array if provided, otherwise just map by index
                if (headers != null && headers.Length != 0)
                    csv.Context.RegisterClassMap(new CustomHeadersMap(headers));
                else
                    csv.Context.RegisterClassMap<IndexHeadersMap>();
                var records = csv.GetRecords<ParsedResult>();
                foreach (var record in records)
                {
                    toReturn.Add(record);
                }
            }

            return toReturn;
        }
    }

    public class ParsedResult
    {
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
        public string Col5 { get; set; }
        public string Col6 { get; set; }
        public string Col7 { get; set; }
        public string Col8 { get; set; }
        public string Col9 { get; set; }
        public string Col10 { get; set; }
        public string Col11 { get; set; }
        public string Col12 { get; set; }
        public string Col13 { get; set; }
        public string Col14 { get; set; }
        public string Col15 { get; set; }
        public string Col16 { get; set; }
    }

    /// <summary>
    /// This is a simple map, it will put the first column to the Col1, second to Col2 and so on
    /// </summary>
    public class IndexHeadersMap : ClassMap<ParsedResult>
    {
        public IndexHeadersMap()
        {
            Map(x => x.Col1).Index(0);
            Map(x => x.Col2).Index(1);
            Map(x => x.Col3).Index(2);
            Map(x => x.Col4).Index(3);
            Map(x => x.Col5).Index(4);
            Map(x => x.Col6).Index(5);
            Map(x => x.Col7).Index(6);
            Map(x => x.Col8).Index(7);
            Map(x => x.Col9).Index(8);
            Map(x => x.Col10).Index(9);
            Map(x => x.Col11).Index(10);
            Map(x => x.Col12).Index(11);
            Map(x => x.Col13).Index(12);
            Map(x => x.Col14).Index(13);
            Map(x => x.Col15).Index(14);
            Map(x => x.Col16).Index(15);
        }
    }

    /// <summary>
    /// This map will use an array of column names and map Col1 to the first element and so on
    /// </summary>
    public class CustomHeadersMap : ClassMap<ParsedResult>
    {
        public CustomHeadersMap(params string[] headers)
        {

            if (headers.Length > 0) Map(x => x.Col1).Name(headers[0]);
            if (headers.Length > 1) Map(x => x.Col2).Name(headers[1]);
            if (headers.Length > 2) Map(x => x.Col3).Name(headers[2]);
            if (headers.Length > 3) Map(x => x.Col4).Name(headers[3]);
            if (headers.Length > 4) Map(x => x.Col5).Name(headers[4]);
            if (headers.Length > 5) Map(x => x.Col6).Name(headers[5]);
            if (headers.Length > 6) Map(x => x.Col7).Name(headers[6]);
            if (headers.Length > 7) Map(x => x.Col8).Name(headers[7]);
            if (headers.Length > 8) Map(x => x.Col9).Name(headers[8]);
            if (headers.Length > 9) Map(x => x.Col10).Name(headers[9]);
            if (headers.Length > 10) Map(x => x.Col11).Name(headers[10]);
            if (headers.Length > 11) Map(x => x.Col12).Name(headers[11]);
            if (headers.Length > 12) Map(x => x.Col13).Name(headers[12]);
            if (headers.Length > 13) Map(x => x.Col14).Name(headers[13]);
            if (headers.Length > 14) Map(x => x.Col15).Name(headers[14]);

            if (headers.Length > 15) Map(x => x.Col16).Name(headers[15]);

            

        }
    }
}
