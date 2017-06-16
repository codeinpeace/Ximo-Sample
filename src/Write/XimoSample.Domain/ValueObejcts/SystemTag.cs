using System.Diagnostics.CodeAnalysis;
using Ximo.Domain;
using Ximo.Validation;

namespace XimoSample.Domain.ValueObejcts
{
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class SystemTag : ValueObject<SystemTag>
    {
        private string _name;

        private SystemTag()
        {
        }

        public SystemTag(string name, bool appliesToExpenses, bool appliesToTimesheets) : this()
        {
            _name = name;
            AppliesToExpenses = appliesToExpenses;
            AppliesToTimesheets = appliesToTimesheets;
        }

        public bool AppliesToExpenses { get; }
        public bool AppliesToTimesheets { get; }

        public string Name
        {
            get => _name;
            private set
            {
                PropertyCheck.NotNullOrWhitespace(value);
                _name = value;
            }
        }
    }
}