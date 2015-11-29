namespace ATT.Infrastructure.Models.Employee
{
    public interface IEmployee
    {
        string Name { get; }
        string Surname { get; }
        int EUID { get; } // Employee Unique Identificator - is shared by his multiple accounts. Whatever account is used at login - system treats him as same Employee
        byte[] Photo { get; } // Loaded separately - per explicit request
    }
}
