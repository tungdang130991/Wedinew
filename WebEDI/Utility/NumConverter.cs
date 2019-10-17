using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEDI.Utility
{
    public class NumConverter : ITypeConverter
    {
        object ITypeConverter.ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }

        string ITypeConverter.ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            //Can xem lai dinh dan
            return value.ToString();
        }
    }
}
