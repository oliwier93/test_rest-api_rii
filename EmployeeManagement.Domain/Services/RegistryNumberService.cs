namespace EmployeeManagement.Domain.Services
{
    public class RegistryNumberGenerator : IRegistryNumberGenerator
    {
        private readonly List<string> _existingRegistryNumbers;

        public RegistryNumberGenerator(List<string> existingRegistryNumbers)
        {
            _existingRegistryNumbers = existingRegistryNumbers;
        }

        public string GenerateNext()
        {
            if (_existingRegistryNumbers == null || !_existingRegistryNumbers.Any())
            {
                return "00000001";
            }

            int maxNumber = _existingRegistryNumbers
                .Select(n => int.Parse(n))
                .Max();

            return (maxNumber + 1).ToString("D8");
        }
    }
}