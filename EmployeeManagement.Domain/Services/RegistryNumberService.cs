namespace EmployeeManagement.Domain.Services
{
    public class RegistryNumberGenerator : IRegistryNumberGenerator
    {
        private readonly List<string> _existingRegistryNumbers;
        private readonly object _lock = new object();

        public RegistryNumberGenerator(List<string> existingRegistryNumbers)
        {
            _existingRegistryNumbers = existingRegistryNumbers ?? new List<string>();
        }

        public string GenerateNext()
        {
            lock (_lock)
            {
                if (!_existingRegistryNumbers.Any())
                {
                    var newNumber = "00000001";
                    _existingRegistryNumbers.Add(newNumber);
                    return newNumber;
                }

                int maxNumber = _existingRegistryNumbers
                    .Select(n => int.Parse(n))
                    .Max();

                var nextNumber = (maxNumber + 1).ToString("D8");
                _existingRegistryNumbers.Add(nextNumber);
                return nextNumber;
            }
        }
    }
}
