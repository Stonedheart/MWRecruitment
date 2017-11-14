using System;
using System.Globalization;

namespace MWApplicationAssignment
{
    public class DateRange
    {
        private string _dateRangeString;
        private DateTime _firstDate;
        private DateTime _secondDate;
        private readonly DateTimeFormatInfo _dateTimeFormat;
        private readonly string _shortDatePattern;
        private string _dayFormat;
        private string _monthFormat;
        private string _yearFormat;
        private bool _isDayFirst;
        private bool _isMonthFirst;
        private bool _isYearFirst;

        public DateRange(DateTime firstDate, DateTime secondDate)
        {
            _firstDate = firstDate;
            _secondDate = secondDate;
            _dateTimeFormat = CultureInfo.CurrentUICulture.DateTimeFormat;
            _shortDatePattern = _dateTimeFormat.ShortDatePattern;
            SetDateSegmentsFormats();
            SetDateSegmentsOrder();
        }

        private void SetDateSegmentsFormats()
        {
            SetDayFormat();
            SetMonthFormat();
            SetYearFormat();
        }

        private void SetDateSegmentsOrder()
        {
            _isDayFirst = false;
            _isMonthFirst = false;
            _isYearFirst = false;

            if (_shortDatePattern.StartsWith("d"))
            {
                _isDayFirst = true;
            }
            if (_shortDatePattern.StartsWith("M"))
            {
                _isMonthFirst = true;
            }
            if (_shortDatePattern.StartsWith("y"))
            {
                _isYearFirst = true;
            }
        }

        private void SetDayFormat()
        {
            foreach (var character in _shortDatePattern)
            { 
                if (Equals(character, 'd'))
                {
                    _dayFormat += "d";
                }
            }
        }

        private void SetMonthFormat()
        {
            foreach (var character in _shortDatePattern)
            {
                if (Equals(character, 'M'))
                {
                    _monthFormat += "M";
                }
            }
        }

        private void SetYearFormat()
        {
            foreach (var character in _shortDatePattern)
            {
                if (Equals(character, 'y'))
                {
                    _yearFormat += "y";
                }
            }
        }

        public override string ToString()
        {
            PrepareDateRangeString();
            return _dateRangeString;
        }

        private void PrepareDateRangeString()
        {
            var separator = _dateTimeFormat.DateSeparator;

            if (!Equals(_firstDate.Year, _secondDate.Year))
            {
                _dateRangeString = $"{_firstDate.ToString(_shortDatePattern)} - {_secondDate.ToString(_shortDatePattern)}";
                return;
            }

            if (Equals(_firstDate, _secondDate))
            {
                _dateRangeString = _firstDate.ToString(_shortDatePattern);
                return;
            }

            if (_isDayFirst)
            {
                SetDateRangeStringInDayFirstFormat(separator);
            }
            if (_isMonthFirst)
            {
                SetDateRangeStringInMonthFirstFormat(separator);
            }
            if (_isYearFirst)
            {
                SetDateRangeStringInYearFirstFormat(separator);
            }
        }

        private void SetDateRangeStringInDayFirstFormat(string separator)
        {
            if (!Equals(_firstDate.Month, _secondDate.Month))
            {
                _dateRangeString = $"{_firstDate.ToString(_dayFormat)}{separator}{_firstDate.ToString(_monthFormat)} - {_secondDate.ToString(_shortDatePattern)}";
                return;
            }

            if (!Equals(_firstDate.Day, _secondDate.Day))
            {
                _dateRangeString = $"{_firstDate.ToString(_dayFormat)} - {_secondDate.ToString(_shortDatePattern)}";
                return;
            }
        }

        private void SetDateRangeStringInMonthFirstFormat(string separator)
        {
            if (!Equals(_firstDate.Month, _secondDate.Month))
            {
                _dateRangeString = $"{_firstDate.ToString(_monthFormat)}{separator}{_firstDate.ToString(_dayFormat)} - {_secondDate.ToString(_shortDatePattern)}";
                return;
            }

            if (!Equals(_firstDate.Day, _secondDate.Day))
            {
                _dateRangeString = $"{_firstDate.ToString(_monthFormat)}{separator}{_firstDate.ToString(_dayFormat)} - {_secondDate.ToString(_dayFormat)}{separator}{_secondDate.ToString(_yearFormat)}";
                return;
            }
        }

        private void SetDateRangeStringInYearFirstFormat(string separator)
        {
            if (!Equals(_firstDate.Month, _secondDate.Month))
            {
                _dateRangeString = $"{_firstDate.ToString(_shortDatePattern)} - {_secondDate.ToString(_monthFormat)}{separator}{_secondDate.ToString(_dayFormat)}";
                return;
            }

            if (!Equals(_firstDate.Day, _secondDate.Day))
            {
                _dateRangeString = $"{_firstDate.ToString(_shortDatePattern)} - {_secondDate.ToString(_dayFormat)}";
                return;
            }
        }
    }
}