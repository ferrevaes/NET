using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Lottery.Domain;

namespace Lottery.UI.Converters
{
    public class DrawNumbersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IList<DrawNumber> drawNumbers = value as IList<DrawNumber>;
            var query = drawNumbers.OrderBy(s => s.Position);
            drawNumbers = query.ToList();
            string numbers = null;

            for (int i = 0; i < drawNumbers.Count; i++)
            {
                DrawNumber number = drawNumbers[i];
                if (i < drawNumbers.Count - 1)
                {
                    numbers += number.Number + ", ";
                }
                else
                {
                    numbers += number.Number;
                }
            }

            return numbers;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
