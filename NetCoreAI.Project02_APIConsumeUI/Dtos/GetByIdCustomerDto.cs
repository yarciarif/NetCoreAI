﻿namespace NetCoreAI.Project02_APIConsumeUI.Dtos
{
    public class GetByIdCustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public decimal CustomerSalary { get; set; }
    }
}
