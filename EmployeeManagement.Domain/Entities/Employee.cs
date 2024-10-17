using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; }
        public string RegistryNumber { get; }
        public string LastName { get; private set; }
        public Gender Gender { get; private set; }

        public Employee(string lastName, Gender gender, string lastRegistryNumber, IRegistryNumberGenerator registryNumberGenerator)
        {
            Id = Guid.NewGuid();
            RegistryNumber = registryNumberGenerator.GenerateNext();
            LastName = ValidateLastName(lastName);
            Gender = ValidateGender(gender);

        }

        public void Update(string lastName, Gender gender)
        {
            LastName = ValidateLastName(lastName);
            Gender = ValidateGender(gender);
        }

        private static string ValidateLastName(string lastName) =>
            !string.IsNullOrWhiteSpace(lastName) && lastName.Length <= 50
                ? lastName
                : throw new ArgumentException("Last name must be between 1 and 50 characters.");

        private static Gender ValidateGender(Gender gender) =>
            Enum.IsDefined(typeof(Gender), gender)
                ? gender
                : throw new ArgumentException("Invalid gender.");
    }
}
