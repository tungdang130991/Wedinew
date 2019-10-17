using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebEDI.Utility
{
   public class DMYDateConverter : ITypeConverter {
    private const String dateFormat = @"yyyy/MM/dd";
        
        object ITypeConverter.ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return null;
        }

        string ITypeConverter.ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            DateTime d = (DateTime)value;
            return d.ToString("yyyy/MM/dd");
        }
    }
}
